using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using AuthenticationServer.Models;
using AuthServer.Dto;

namespace AuthServer.Services.JwtTokenService
{
	public class JwtGenerator
	{
		public JwtGenerator()
		{
		}

        public static string CreateToken(string email)
        {
            var expiration = DateTime.UtcNow.AddMinutes(1);
            var token = CreateJwtToken(
                CreateClaims(email),
                CreateSigningCredentials(),
                expiration
            );
            var tokenHandler = new JwtSecurityTokenHandler();

            //_logger.LogInformation("JWT Token created");

            return tokenHandler.WriteToken(token);
        }

        private static JwtSecurityToken CreateJwtToken(List<Claim> claims, SigningCredentials credentials,
        DateTime expiration) =>
        new(
            new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Jwt")["ValidIssuer"],
            new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Jwt")["ValidAudience"],
            claims,
            expires: expiration,
            signingCredentials: credentials
        );

        private static List<Claim> CreateClaims(string email)
        {
            //not understood.
            try
            {
                var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Aud, email)                
            };

                return claims;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static SigningCredentials CreateSigningCredentials()
        {
            var symmetricSecurityKey = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Jwt")["Key"];

            return new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(symmetricSecurityKey!)
                ),
                SecurityAlgorithms.HmacSha256
            );
        }
    }
}

