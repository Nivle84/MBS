using System;
using System.Collections.Generic;
using System.Text;
using BC = BCrypt.Net.BCrypt;

namespace SplashScreenTest02.Services
{
	public class PasswordHasher
	{
		public string Hasher(string passToHash)
		{
			return BC.HashPassword(passToHash);
		}

		public bool HashVerificatoin(string passToVerify, string hash)
		{
			return BC.Verify(passToVerify, hash);
		}
	}
}
