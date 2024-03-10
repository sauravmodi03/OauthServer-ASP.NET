using System;
namespace AuthenticationServer.Services.Email
{
	public class EmailTemplate
	{

		public static string GetAccountVerificationTemplate()
		{
            var file = Path.Combine(Directory.GetCurrentDirectory(), "Services", "Email", "AccountVerificationTemplate.html");
			var sr = new StreamReader(file);
			return sr.ReadToEnd();
        }
    }
}

