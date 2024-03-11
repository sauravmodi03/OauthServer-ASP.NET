using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AuthServer.Dto;

namespace AuthenticationServer
{
    //[Keyless]
    public class User
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
        public string? FirstName { get; set; }
		public string? LastName { get; set; }
        public string? Email { get; set; }
		public string? Password { get; set; }
		public bool EmailVerified { get; set; } = false;
		public string Role { get; set; } = "ROLE_USER";
		
		public User()
		{
		}

        public User(string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        public User(UserDto dto)
        {
            FirstName = dto.FirstName;
            LastName = dto.LastName;
            Email = dto.Email;
            Password = dto.Password;
        }
    }
}

