using System.Security.Cryptography;
using System.Text;

namespace ReservationSystem.API.Helpers.Hashing
{
    public static class HashingPassword
    {
        const int KEY_SIZE = 64;
        const int ITERATIONS = 350000;
        private static readonly HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        public static string HashPasword(string password, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(KEY_SIZE);

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                ITERATIONS,
                hashAlgorithm,
                KEY_SIZE);

            return Convert.ToHexString(hash);
        }

        public static bool VerifyPassword(string password, string? hash, byte[]? salt)
        {
            if (hash == null || salt == null)
            {
                return false;
            }

            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, ITERATIONS, hashAlgorithm, KEY_SIZE);

            return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hash));
        }
    }
}
