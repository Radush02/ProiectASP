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

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
        public async Task<SignInResult> LoginAsync(UserLoginDTO login)
        {
            var result = await _signInManager.PasswordSignInAsync(login.UserName, login.Parola, login.Remember, lockoutOnFailure: false);
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