
using HospitalAM.Core.Entities;
using HospitalAM.Core.Enums;
using HospitalAM.Core.Interfaces;
using System.Security.Cryptography;

namespace HospitalAM.Application.Services
{
    public class PasswordHasher : IPasswordHasher<Login>
    {
        private const int Iterations = 310_000;   // robusto para 2025
        private const int SaltSize = 16;        // 128 bits
        private const int KeySize = 32;        // 256 bits
        private static readonly HashAlgorithmName Algo = HashAlgorithmName.SHA256;

        public string HashPassword(Login user, string password)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password cannot be empty.", nameof(password));

            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, Algo, KeySize);

            return $"v1|{Iterations}|{Convert.ToBase64String(salt)}|{Convert.ToBase64String(hash)}";
        }

        public PasswordVerifyResult VerifyHashedPassword(Login user, string hashedPassword, string providedPassword)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));
            if (string.IsNullOrWhiteSpace(hashedPassword) || string.IsNullOrEmpty(providedPassword))
                return PasswordVerifyResult.Failed;

            var parts = hashedPassword.Split('|', 4);
            if (parts.Length != 4 || parts[0] != "v1")
                return PasswordVerifyResult.Failed;

            if (!int.TryParse(parts[1], out int iter))
                return PasswordVerifyResult.Failed;

            byte[] salt, expected;
            try
            {
                salt = Convert.FromBase64String(parts[2]);
                expected = Convert.FromBase64String(parts[3]);
            }
            catch
            {
                return PasswordVerifyResult.Failed;
            }

            byte[] actual = Rfc2898DeriveBytes.Pbkdf2(providedPassword, salt, iter, Algo, expected.Length);
            bool ok = CryptographicOperations.FixedTimeEquals(actual, expected);
            if (!ok) return PasswordVerifyResult.Failed;

            // Se as iterações salvas forem menores que as atuais, sugere rehash
            return iter == Iterations ? PasswordVerifyResult.Success
                                      : PasswordVerifyResult.SuccessRehashNeeded;
        }
    }
}
