using System;
using AuthenticationServer.Models;

namespace AuthenticationServer.Services
{
	public interface IAuthenticationService
	{
		bool Login(AuthenticationModel modal);

        bool Register(AuthenticationModel model);

        void VerifyAccount(string token);

    }
}

