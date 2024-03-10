﻿using System;
using System.IdentityModel.Tokens.Jwt;
using AuthServer.Models;

namespace AuthServer.Services.JwtTokenService
{
	public class JwtDecoder
	{
        private static JwtSecurityToken ConvertJwtStringToJwtSecurityToken(string? jwt)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwt);

            return token;
        }

        public static JwtTokenModal DecodeJwt(string? jwt)
        {

            var token = ConvertJwtStringToJwtSecurityToken(jwt);

            var keyId = token.Header.Kid;
            var audience = token.Audiences.ToList();
            var claims = token.Claims.Select(claim => (claim.Type, claim.Value)).ToList();

            return new JwtTokenModal(
                keyId,
                token.Issuer,
                audience,
                claims,
                token.ValidTo,
                token.SignatureAlgorithm,
                token.RawData,
                token.Subject,
                token.ValidFrom,
                token.EncodedHeader,
                token.EncodedPayload
            );
        }

        public static string GetClaimValue(JwtTokenModal model, string claim)
        {
            return model.Claims.First(c => c.Type == claim).Value;
        }
    }
}

