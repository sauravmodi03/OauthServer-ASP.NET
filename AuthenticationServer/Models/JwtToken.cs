using System;
namespace AuthServer.Models
{
	public class JwtToken
	{
        public JwtToken(string email, string token)
        {
            Email = email;
            Token = token;
        }

        public string? Email { get; set; }
		public string? Token { get; set; }

	}
}

