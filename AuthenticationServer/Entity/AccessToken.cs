using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthServer.Entity
{
	public class AccessToken
	{

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
		public string Email { get; set; }
		public string Token { get; set; }
		public bool TokenValid { get; set; } = true;

        public AccessToken(string email, string token)
        {
            Email = email;
            Token = token;
        }
    }
}

