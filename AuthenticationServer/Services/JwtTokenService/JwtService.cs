using System;
using AuthServer.Models;
using AuthServer.Repository;

namespace AuthServer.Services.JwtTokenService
{
	public class JwtService
	{
        private readonly AccessTokenRepository tokenRepository;

        public JwtService(AccessTokenRepository tokenRepository)
        {
            this.tokenRepository = tokenRepository;
        }

        public JwtToken GetActiveTokenByEmail(string Email)
        {
            var token = tokenRepository.GetActiveTokenByEmail(Email);
           
            return new JwtToken(token.Email, token.Token);
        }

        public List<JwtToken> GetTokensByEmail(string Email)
        {
            var tokens = tokenRepository.GetAllByEmail(Email);
            List<JwtToken> jwtTokens = new List<JwtToken>();
            foreach(var token in tokens)
            {
                jwtTokens.Add(new JwtToken(token.Email, token.Token));
            }

            return jwtTokens;
        }
    }
}

