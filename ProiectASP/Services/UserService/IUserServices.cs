using System.Collections.Generic;
using System.Threading.Tasks;
using ProiectASP.Models;

namespace ProiectASP.Services
{
    public interface IUserServices
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int userId);
        Task CreateUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(int userId);
        Task ChangePassword(string username, string oldPass, string newPass);
        Task CreateWithPassword(User u, string password);
        Task<bool> Login(string username, string password);
        int getHighestUserID();
    }
}
