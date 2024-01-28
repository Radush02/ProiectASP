using Microsoft.EntityFrameworkCore;
using ProiectASP.Data;
using ProiectASP.Models;
using ProiectASP.Repositories;
using System.Security.Cryptography;
using System.Text;

namespace ProiectASP.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public UserRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

    }
}