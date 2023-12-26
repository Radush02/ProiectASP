using System.Collections.Generic;
using System.Threading.Tasks;
using ProiectASP.Data;
using ProiectASP.Models;
using ProiectASP.Exceptions;

namespace ProiectASP.Services
{
    public class UserService : IUserServices
    {
        private readonly ApplicationDBContext _dbContext;

        public UserService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await Task.FromResult(_dbContext.User.ToList());
        }

        public async Task<User> GetUserById(int userId)
        {
            var user = await _dbContext.User.FindAsync(userId);

            if (user == null){
                throw new NotFoundException($"Nu s-a gasit user cu ID-ul {userId}.");
            }
            return user;
        }

        public async Task CreateUser(User user)
        {
            _dbContext.User.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUser(User user)
        {
            _dbContext.User.Update(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUser(int userId)
        {
            var userToRemove = await _dbContext.User.FindAsync(userId);
            if (userToRemove != null)
            {
                _dbContext.User.Remove(userToRemove);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}