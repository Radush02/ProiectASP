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
    }
}
