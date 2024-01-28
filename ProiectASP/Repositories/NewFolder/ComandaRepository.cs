
using Microsoft.EntityFrameworkCore;
using ProiectASP.Data;
using ProiectASP.Models;

namespace ProiectASP.Repositories
{
    public class ComandaRepository :IComandaRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public ComandaRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
 
    }
}
