using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ResourceServer.Models;
using ResourceServer.Services.JwtTokenService;

namespace ResourceServer.Services
{
	public class AuthorizationService
	{
		private readonly JwtService jwtService;

		public AuthorizationService(JwtService _jwtservice)
		{
			jwtService = _jwtservice;
		}

		public bool ValidateAccesToken(string? JwtBearer)
		{
			var encodedJwt = JwtBearer!.Replace("Bearer ", "");

			if (!JwtDecoder.IsTokenValid(encodedJwt)) return false;

			var decodedToken = JwtDecoder.DecodeJwt(encodedJwt);
			var userEmail = JwtDecoder.GetClaimValue(decodedToken, JwtRegisteredClaimNames.Aud);

			JwtToken token = jwtService.GetActiveTokenFromAuthServer(userEmail).Result;

			if (!token.Token.Equals(encodedJwt)) return false;

			return true;

		}
	}
}

