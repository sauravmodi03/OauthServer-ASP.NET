using System;
namespace AuthenticationServer.Models
{
	public class MailData
	{
		public string? EmailToId { get; set; }
        public string? EmailToName { get; set; }
        public string? EmailToSubject { get; set; }
        public string? VerificationURL { get; set; }

        public MailData()
		{
		}
	}
}

