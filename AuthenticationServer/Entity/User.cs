using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AuthenticationServer.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationServer
{
    //[Keyless]
    public class User
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string Email { get; set; }

		public string Password { get; set; }

		public bool EmailVerified { get; set; } = false;

		public string Role { get; set; } = "ROLE_USER";
		
		public User()
		{
			Email = "";
			Password = "";
		}

        public User(string _Email, string _Password)
        {
			this.Email = _Email;
			this.Password = _Password;
        }
        
    }
}

