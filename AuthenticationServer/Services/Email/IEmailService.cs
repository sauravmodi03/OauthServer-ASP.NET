using System;
using AuthenticationServer.Models;

namespace AuthenticationServer.Services
{
	public interface IEmailService
	{
		void SendEmail(MailData data);
	}
}

