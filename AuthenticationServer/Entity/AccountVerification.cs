using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationServer.Models
{
    
    public class AccountVerification
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Email { get; set; }
		public string Token { get; set; }
		public long CreatedAt { get; } = DateTime.Now.Ticks;
        public bool TokenValid { get; set; } = true;

		public AccountVerification(string Email, string Token)
		{
			this.Email = Email;
			this.Token = Token;
		}
	}
}

