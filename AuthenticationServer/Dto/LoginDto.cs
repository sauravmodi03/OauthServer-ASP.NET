﻿using System;
namespace AuthServer.Dto
{
	public class LoginDto
	{

        public string Email { get; set; }
        public string Password { get; set; }

        public LoginDto(string email, string password)
        {
            Email = email;
            Password = password;
        }

	}
}

