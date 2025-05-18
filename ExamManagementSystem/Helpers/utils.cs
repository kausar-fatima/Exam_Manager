using System;
using System.Security.Cryptography;
using System.Text;

namespace ExamManagementSystem.Controllers
{
    public static class Utils
    {
        public static class PasswordHasher
        {
            public static string HashPassword(string password)
            {
                var salt = GenerateSalt();
                using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256))
                {
                    var hash = pbkdf2.GetBytes(32); // 256-bit hash
                    return $"{Convert.ToBase64String(salt)}${Convert.ToBase64String(hash)}";
                }
            }

            public static bool VerifyPassword(string password, string storedHash)
            {
                var parts = storedHash.Split('$');
                var salt = Convert.FromBase64String(parts[0]);
                var storedHashBytes = Convert.FromBase64String(parts[1]);

                using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256))
                {
                    var hash = pbkdf2.GetBytes(32);
                    return CompareHashes(hash, storedHashBytes);
                }
            }


            private static byte[] GenerateSalt(int length = 16)
            {
                var salt = new byte[length];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(salt);
                }
                return salt;
            }

            private static bool CompareHashes(byte[] hash1, byte[] hash2)
            {
                if (hash1.Length != hash2.Length)
                    return false;

                for (int i = 0; i < hash1.Length; i++)
                {
                    if (hash1[i] != hash2[i])
                        return false;
                }
                return true;
            }
        }
    }
}
