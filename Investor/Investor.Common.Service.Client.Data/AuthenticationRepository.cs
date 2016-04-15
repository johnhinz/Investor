using Investor.Common.Shared.EntityFramework;
using Investor.Common.Shared.Interfaces;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using Investor.Common.Shared.Pocos;

namespace Investor.Common.Service.Client.Data
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private InvestorContext _repository;

        public AuthenticationRepository()
        {
            _repository = new InvestorContext();
        }
        public bool Create(string user, string pass)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string user, string pass)
        {
            throw new NotImplementedException();
        }

        public bool Read(string user, string pass)
        {
            return true;
        }

        public bool Update(string user, string pass)
        {
            throw new NotImplementedException();
        }

        public bool Verify(string user, string pass)
        {
            UserPoco userPoco = null;

            try
            {
                userPoco = _repository.Users.Where(u => u.UserName == user).Single();
            }
            catch
            {
                // user not found
                return false;
            }

            //byte[] salt = new byte[8];
            //salt[0] = 0x20;
            //salt[0] = 0x21;
            //salt[0] = 0x22;
            //salt[0] = 0x23;
            //salt[0] = 0x24;
            //salt[0] = 0x25;
            //salt[0] = 0x26;
            //salt[0] = 0x27;

            //var hash = ComputeHash(pass, salt);




            return VerifyHash(pass, userPoco.Pass);
        }

        private string ComputeHash(string plainText, byte[] saltBytes)
        {
            // If salt is not specified, generate it.
            if (saltBytes == null)
            {
                // Define min and max salt sizes.
                int minSaltSize = 4;
                int maxSaltSize = 8;

                // Generate a random number for the size of the salt.
                Random random = new Random();
                int saltSize = random.Next(minSaltSize, maxSaltSize);

                // Allocate a byte array, which will hold the salt.
                saltBytes = new byte[saltSize];

                // Initialize a random number generator.
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

                // Fill the salt with cryptographically strong byte values.
                rng.GetNonZeroBytes(saltBytes);
            }
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] plainTextWithSaltBytes =
            new byte[plainTextBytes.Length + saltBytes.Length];
            for (int i = 0; i < plainTextBytes.Length; i++)
                plainTextWithSaltBytes[i] = plainTextBytes[i];

            for (int i = 0; i < saltBytes.Length; i++)
            {
                plainTextWithSaltBytes[plainTextBytes.Length + i] = saltBytes[i];
            }
            HashAlgorithm hash = new SHA512Managed();
            byte[] hashBytes = hash.ComputeHash(plainTextWithSaltBytes);
            byte[] hashWithSaltBytes = new byte[hashBytes.Length + saltBytes.Length];
            for (int i = 0; i < hashBytes.Length; i++)
            {
                hashWithSaltBytes[i] = hashBytes[i];
            }
            for (int i = 0; i < saltBytes.Length; i++)
            {
                hashWithSaltBytes[hashBytes.Length + i] = saltBytes[i];
            }
            return Convert.ToBase64String(hashWithSaltBytes);
        }
        public bool VerifyHash(string plainText,string hashValue)
        {
            const int hashSizeInBytes = 64;

            byte[] hashWithSaltBytes = Convert.FromBase64String(hashValue);
            if (hashWithSaltBytes.Length < hashSizeInBytes)
                return false;
            byte[] saltBytes = new byte[hashWithSaltBytes.Length - hashSizeInBytes];
            for (int i = 0; i < saltBytes.Length; i++)
                saltBytes[i] = hashWithSaltBytes[hashSizeInBytes + i];
            string expectedHashString = ComputeHash(plainText, saltBytes);
            // If the computed hash matches the specified hash,
            // the plain text value must be correct.
            return (hashValue == expectedHashString);
        }
    }
}