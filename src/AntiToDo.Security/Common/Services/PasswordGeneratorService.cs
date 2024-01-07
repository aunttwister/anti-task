using AntiToDo.Security.Common.Interfaces;
using AntiToDo.Security.Common.Options;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using System.Text;

namespace AntiToDo.Security.Common.Services
{
    public class PasswordGeneratorService : IPasswordGeneratorService
    {
        private readonly PasswordGeneratorServiceOptions _options;
        public PasswordGeneratorService(IOptions<PasswordGeneratorServiceOptions> options)
        {
            _options = options.Value;
        }
        public (byte[] hashPassword, byte[] salt) GenerateHash(string password)
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                var salt = new byte[_options.SaltSize];
                rng.GetBytes(salt);
                var hash = HashPassword(password, salt);

                return (hash, salt);
            }
        }
        public bool CompareHash(string password, byte[] salt, byte[] storedHash)
        {
            byte[] inputHash = HashPassword(password, salt);

            return inputHash.SequenceEqual(storedHash);
        }
        private static byte[] HashPassword(string password, byte[] salt)
        {
            byte[] value = Encoding.UTF8.GetBytes(password);
            return Hash(value, salt);
        }
        private static byte[] Hash(byte[] value, byte[] salt)
        {
            byte[] saltedValue = value.Concat(salt).ToArray();

            return SHA256.HashData(saltedValue);
        }
    }
}
