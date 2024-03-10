using System;
using SecureTokenGeneratR;

namespace AuthenticationServer.Services
{
	public class TokenGenerator
	{
		public static SecureTokenGenerator tokenG = new SecureTokenGenerator();

		public TokenGenerator(SecureTokenGenerator _generator)
		{
			tokenG = _generator;
		}

		public static long GenerateTokenDefault()
		{
			return new Random().Next(100000, 999999);
		}
	}
}

