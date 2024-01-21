using ProiectASP.Models;

namespace ProiectASP.Repositories
{
    public interface IUserRepository
    {
        Task CreateUserWithHashedPassword(User user,string password);
        Task<bool> ChangePassword(string username, string oldPass, string newPass);

        Task<bool> Login(string username, string password);
    }
}