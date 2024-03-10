
namespace AuthenticationServer.Services
{
    using BCrypt.Net;

    public class EncryptionService
	{
		public EncryptionService()
		{
		}

		public static String Encrypt(string value)
		{
			return BCrypt.HashPassword(value);
		}

		public static bool Verify(string value, string encrypted)
		{
			return BCrypt.Verify(value, encrypted);
		}

	}
}

