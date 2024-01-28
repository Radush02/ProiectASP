using System.Collections.Generic;
using System.Threading.Tasks;
using ProiectASP.Models;
using ProiectASP.Models.DTOs.UserDTOs;

namespace ProiectASP.Services
{
    public interface IUserServices
    {
        Task<IEnumerable<UserInfoDTO>> GetAllUsers();
        Task<UserInfoDTO> GetUserById(int userId);
        Task CreateUser(User user);
        Task UpdateUser(FullUserDTO user);
        Task DeleteUser(int userId);
        Task ChangePassword(string username, string oldPass, string newPass);
        Task CreateWithPassword(FullUserDTO u);
        Task AddAdresa(FullUserDTO u);
        Task<bool> Login(string username, string password);
        int getHighestUserID();
    }
}
