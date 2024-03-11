using System;
using AuthenticationServer.Models;
using AuthServer.Dto;

namespace AuthenticationServer.Services
{
	public interface IAuthenticationService
	{
        AuthResponseDto Login(string modal);

        AuthResponseDto Register(UserDto model);

        void VerifyAccount(string token);

    }
}

