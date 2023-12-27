using System.Collections.Generic;
using System.Threading.Tasks;
using ProiectASP.Data;
using ProiectASP.Models;
using ProiectASP.Exceptions;
using Microsoft.EntityFrameworkCore;
using ProiectASP.Repositories;

namespace ProiectASP.Services
{
    public class UserService : IUserServices
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public UserService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await Task.FromResult(_dbContext.User.Include(u=>u.AdreseLivrare).ToList());
        }
        public async Task<User> GetUserById(int userId)
        {
            var user = await _dbContext.User.Include(u=>u.AdreseLivrare).FirstOrDefaultAsync(u=>u.ID==userId);

            if (user == null){
                throw new NotFoundException($"Nu exista user cu ID-ul {userId}.");
            }
            return user;
        }

        public async Task CreateUser(User user)
        {
            _dbContext.User.Add(user);

            if (user.AdreseLivrare != null){
                _dbContext.AdresaLivrare.Add(user.AdreseLivrare);
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUser(User user)
        {
            _dbContext.User.Update(user);

            if (user.AdreseLivrare != null){
                _dbContext.AdresaLivrare.Update(user.AdreseLivrare);
            }

            await _dbContext.SaveChangesAsync();
        }
        public async Task ChangePassword(string username, string oldPass, string newPass)
        {
            bool passwordChanged = await _userRepository.ChangePassword(username, oldPass, newPass);

            if (!passwordChanged)
            {
                throw new NotFoundException("Nu s-a putut schimba parola. Parola veche gresita.");
            }
        }
        public async Task DeleteUser(int userId)
        {

            var userToRemove = await _dbContext.User
                .Include(u => u.AdreseLivrare)
                .FirstOrDefaultAsync(u => u.ID == userId);

            if (userToRemove == null)
            {
                throw new NotFoundException($"Nu exista user cu ID-ul {userId}.");
            }

            if (userToRemove != null)
            {
                if (userToRemove.AdreseLivrare != null){
                    _dbContext.AdresaLivrare.Remove(userToRemove.AdreseLivrare);
                }
                _dbContext.User.Remove(userToRemove);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}