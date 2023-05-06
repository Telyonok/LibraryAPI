using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace Library.Application.Authentication
{
    public static class PasswordHasher
    {
        private static readonly byte[] salt = new byte[] { 0x11, 0x22, 0x33, 0x44, 0x55 };
        public static string Hash(string password)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            return hashed;
        }
    }
}
