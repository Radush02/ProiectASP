using System.Collections.Generic;
using System.Threading.Tasks;
using ProiectASP.Data;
using ProiectASP.Models;
using ProiectASP.Exceptions;
using Microsoft.EntityFrameworkCore;
using ProiectASP.Repositories;
using ProiectASP.Models.DTOs.UserDTOs;

namespace ProiectASP.Services
{
    public class UserService : IUserServices
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly IUserRepository _userRepository;

        public UserService(ApplicationDBContext dbContext, IUserRepository userRepository)
        {
            _dbContext = dbContext;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserInfoDTO>> GetAllUsers()
        {
            var usersFromDb = await Task.FromResult(_dbContext.User.Include(u => u.AdreseLivrare).ToList());

            List<UserInfoDTO> users = new List<UserInfoDTO>();

            foreach (var user in usersFromDb)
            {
                UserInfoDTO userInfo = new UserInfoDTO
                {
                    UserName = user.UserName,
                    Nume = user.Nume,
                    Adresa = user.AdreseLivrare?.Adresa, 
                    Oras = user.AdreseLivrare?.Oras
                };

                users.Add(userInfo);
            }

            return users;
        }
        public async Task<UserInfoDTO> GetUserById(int userId)
        {
            var user = await _dbContext.User.Include(u=>u.AdreseLivrare).FirstOrDefaultAsync(u=>u.ID==userId);

            if (user == null){
                throw new NotFoundException($"Nu exista user cu ID-ul {userId}.");
            }


            return new UserInfoDTO
            {
                UserName = user.UserName,
                Nume = user.Nume,
                Adresa = user.AdreseLivrare?.Adresa,
                Oras = user.AdreseLivrare?.Oras
            };
        }

        public async Task CreateUser(User user)
        {
            _dbContext.User.Add(user);

            if (user.AdreseLivrare != null){
                _dbContext.AdresaLivrare.Add(user.AdreseLivrare);
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUser(FullUserDTO u)
        {
            var user = await _dbContext.User.Include(k=>k.AdreseLivrare).FirstOrDefaultAsync(k=>k.UserName==u.UserName);
            if (user == null)
            {
                throw new NotFoundException($"Nu exista userul cu username {u.UserName}");
            }
            user.Nume = u.Nume;

            _dbContext.User.Update(user);

            user.AdreseLivrare.Adresa = u.Adresa;
            user.AdreseLivrare.Oras = u.Oras;
            _dbContext.AdresaLivrare.Update(user.AdreseLivrare);
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
        public async Task AddAdresa(FullUserDTO u)
        {
            int highestUserId = getHighestUserID();
            var a = new AdresaLivrare
            {
                ID = highestUserId,
                Adresa = u.Adresa,
                Oras = u.Oras
            };
            _dbContext.AdresaLivrare.Add(a);
            await _dbContext.SaveChangesAsync();
        }
        public async Task CreateWithPassword(FullUserDTO usr)
        {
            int highestUserId = getHighestUserID();
            var u = new User
            {
                ID = highestUserId + 1,
                UserName = usr.UserName,
                Nume = usr.Nume
            };
            await _userRepository.CreateUserWithHashedPassword(u, usr.Parola);
        }
        public async Task<bool> Login(string username, string password)
        {
           return await _userRepository.Login(username, password);
        }
        public int getHighestUserID()
        {
            try
            {
                return _dbContext.User.Max(u => u.ID);
            }
            catch
            {
                return 1;
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