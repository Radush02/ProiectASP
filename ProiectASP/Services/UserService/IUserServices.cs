using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ProiectASP.Models;
using ProiectASP.Models.DTOs.UserDTOs;

namespace ProiectASP.Services
{
    public interface IUserServices
    {
        Task<IdentityResult> RegisterAsync(FullUserDTO user);
        Task<KeyValuePair<SignInResult, string>> LoginAsync(UserLoginDTO login);
        Task LogoutAsync();
        Task<IdentityResult> ChangePasswordAsync(UserChangePassDTO user);
        Task MakeAdmin(string username);


    }
}
