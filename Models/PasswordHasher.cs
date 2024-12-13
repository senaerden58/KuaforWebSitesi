using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace KuaforWebSitesi.Models
{
    public class PasswordHasher
    {
        public string HashPassword(string password)
        {
            // Salt oluşturuluyor
            byte[] salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            // Şifreyi hash'lemek
            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashedPassword;
        }

        public bool VerifyPassword(string password, string storedHash)
        {
            // Burada hash karşılaştırması yapılır
            // Bu metodda hash karşılaştırma işlemi yapılacak.
            return storedHash == HashPassword(password);
        }
    }
}
