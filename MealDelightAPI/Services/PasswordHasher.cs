using System.Security.Cryptography;

namespace MealDelightAPI.Services
{
    public sealed class PasswordHasher
    {
        private const int saltSize = 16;
        private const int hashSize = 32;
        private const int iterations = 100000;

        private static readonly HashAlgorithmName algorithm = HashAlgorithmName.SHA512;

        public string Hash(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(saltSize);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, algorithm, hashSize);

            return $"{Convert.ToHexString(hash)}-{Convert.ToHexString(salt)}";
        }

        public bool Verify(string password, string passwordHash)
        {
            string[] parts = passwordHash.Split("-");
            byte[] hash = Convert.FromHexString(parts[0]);
            byte[] salt = Convert.FromHexString(parts[1]);

            byte[] inputHash = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, algorithm, hashSize);

            return CryptographicOperations.FixedTimeEquals(hash, inputHash);
        }
    }
}
