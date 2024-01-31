using System.IdentityModel.Tokens.Jwt;
using ProiectASP.Models;
using System.Security.Claims;
using ProiectASP.Models.DTOs.UserDTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
        public async Task MakeAdmin(string username)
        {
            var x = await _userManager.FindByNameAsync(username);
            await _userManager.AddToRoleAsync(x, "Admin");
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

            if (result.Succeeded){
                await _userManager.AddToRoleAsync(newUser, "User");
            }

            return result;
        }
        public async Task<KeyValuePair<SignInResult, string>> LoginAsync(UserLoginDTO login)
        {
            var user = await _userManager.FindByNameAsync(login.UserName);
            var result = await _signInManager.PasswordSignInAsync(login.UserName, login.Parola, login.Remember, lockoutOnFailure: false);
            return new KeyValuePair<SignInResult, string>(result,await TokenHandler(user, await _userManager.IsInRoleAsync(user, "Admin")));
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
        public async Task<string> TokenHandler(User user,bool isAdmin)
        {

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier , user.UserName),
                    new Claim(ClaimTypes.Name , user.Nume),
                    new Claim(ClaimTypes.Email , user.Email),
                    new Claim(ClaimTypes.MobilePhone , user.NrTelefon),
                    new Claim(ClaimTypes.Role,isAdmin?"Admin":"User")
                };
            var token = new JwtSecurityToken(
                issuer: "https://localhost:7259/",
                audience: "https://localhost:7259/",
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                notBefore: DateTime.Now,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("rGSSVGNjKoM4qq41wHcssBm4JDzDxfc93rfcAy+id0I=")),
                SecurityAlgorithms.HmacSha256)
                );
            await _signInManager.SignInAsync(user, isPersistent: false);
            var x = new JwtSecurityTokenHandler().WriteToken(token);
            return x;
        }
    }

}