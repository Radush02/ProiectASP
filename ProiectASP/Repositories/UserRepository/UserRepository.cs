using Microsoft.EntityFrameworkCore;
using ProiectASP.Data;
using ProiectASP.Models;
using ProiectASP.Repositories;
using System.Security.Cryptography;
using System.Text;

namespace ProiectASP.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public UserRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateUserWithHashedPassword(User user, string password)
        {
            byte[] saltBytes = GenerateSalt();
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] combinedBytes = new byte[passwordBytes.Length + saltBytes.Length];
            Buffer.BlockCopy(passwordBytes, 0, combinedBytes, 0, passwordBytes.Length);
            Buffer.BlockCopy(saltBytes, 0, combinedBytes, passwordBytes.Length, saltBytes.Length);

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(combinedBytes);
                user.PassHash = Convert.ToBase64String(hashBytes);
                user.Salt = Convert.ToBase64String(saltBytes);
            }

            _dbContext.User.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        private byte[] GenerateSalt()
        {
            byte[] salt = new byte[32];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }
        public async Task<bool> ChangePassword(string username, string oldPass, string newPass)
        {
            var user = await _dbContext.User.SingleOrDefaultAsync(u => u.UserName == username);
            if (user == null)
            {
                return false;
            }

            byte[] saltBytes = Convert.FromBase64String(user.Salt);
            byte[] oldPassBytes = Encoding.UTF8.GetBytes(oldPass);
            byte[] combinedBytes = new byte[oldPassBytes.Length + saltBytes.Length];
            Buffer.BlockCopy(oldPassBytes, 0, combinedBytes, 0, oldPassBytes.Length);
            Buffer.BlockCopy(saltBytes, 0, combinedBytes, oldPassBytes.Length, saltBytes.Length);

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(combinedBytes);
                string hashedOldPass = Convert.ToBase64String(hashBytes);

                if (hashedOldPass != user.PassHash)
                {
                    return false;
                }
            }
            byte[] newSaltBytes = GenerateSalt();
            byte[] newPassBytes = Encoding.UTF8.GetBytes(newPass);
            byte[] newCombinedBytes = new byte[newPassBytes.Length + newSaltBytes.Length];
            Buffer.BlockCopy(newPassBytes, 0, newCombinedBytes, 0, newPassBytes.Length);
            Buffer.BlockCopy(newSaltBytes, 0, newCombinedBytes, newPassBytes.Length, newSaltBytes.Length);

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] newHashBytes = sha256.ComputeHash(newCombinedBytes);
                user.PassHash = Convert.ToBase64String(newHashBytes);
                user.Salt = Convert.ToBase64String(newSaltBytes);
            }
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}