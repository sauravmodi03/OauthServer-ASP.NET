using System;
namespace AuthServer.Dto
{
	public class AuthResponseDto
	{

        public string Email { get; set; }
        public string AccessToken { get; set; }
        public string Message { get; set; }

        public AuthResponseDto(string email, string accessToken, string message)
        {
            Email = email;
            AccessToken = accessToken;
            Message = message;
        }
	}
}

