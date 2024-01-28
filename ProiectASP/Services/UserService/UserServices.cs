using System.Collections.Generic;
using System.Threading.Tasks;
using ProiectASP.Data;
using ProiectASP.Models;
using ProiectASP.Exceptions;
using Microsoft.EntityFrameworkCore;
using ProiectASP.Repositories;
using ProiectASP.Models.DTOs.UserDTOs;
using Microsoft.AspNetCore.Identity;

namespace ProiectASP.Services
{
    public class UserService : IUserServices
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ApplicationDBContext _dbContext;
        public UserService(UserManager<User> userManager, SignInManager<User> signInManager,ApplicationDBContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
        }
        public async Task<IdentityResult> RegisterAsync(FullUserDTO user)
        {
            var newUser = new User
            {
                UserName = user.UserName,
                Nume = user.Nume,
                Email = user.Email,
                NrTelefon = user.NrTelefon,
                AdreseLivrare = new AdresaLivrare
                {
                    Oras = user.Oras,
                    Adresa = user.Adresa
                }
            };
            var result = await _userManager.CreateAsync(newUser, user.Parola);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(newUser, isPersistent: false);
            }

            return result;
        }
        public async Task<SignInResult> LoginAsync(string userName, string password, bool rememberMe)
        {
            var result = await _signInManager.PasswordSignInAsync(userName, password, rememberMe, lockoutOnFailure: false);
            return result;
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> ChangePasswordAsync(UserChangePassDTO user)
        {
            var u = await _userManager.FindByNameAsync(user.UserName);

            var result = await _userManager.ChangePasswordAsync(u, user.ParolaVeche, user.ParolaNoua);
            return result;
        }
    }

}