using System.Security.Cryptography;

namespace Common
{
    public class PasswordUtils
    {
        public static string HashPassword(string password)
        {
            // Generate a 128-bit salt using a secure PRNG
            byte[] salt = RandomNumberGenerator.GetBytes(16);

            // Derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100_000, HashAlgorithmName.SHA256);
            byte[] key = pbkdf2.GetBytes(32);

            // Combine the salt and key
            byte[] hashBytes = new byte[48];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(key, 0, hashBytes, 16, 32);

            // Convert to base64
            var base64Hash = Convert.ToBase64String(hashBytes);

            return base64Hash;
        }

        public static bool VerifyPassword(string storedHash, string passwordToCheck)
        {
            // Extract bytes
            byte[] hashBytes = Convert.FromBase64String(storedHash);

            // Get salt
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            // Derive key from the provided password using the salt and iteration count
            using var pbkdf2 = new Rfc2898DeriveBytes(passwordToCheck, salt, 100_000, HashAlgorithmName.SHA256);
            byte[] key = pbkdf2.GetBytes(32);

            // Compare the results
            for (int i = 0; i < 32; i++)
            {
                if (hashBytes[i + 16] != key[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
