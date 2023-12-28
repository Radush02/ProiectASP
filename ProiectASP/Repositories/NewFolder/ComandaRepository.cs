
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
        public async Task<IEnumerable<ComandaDetails>> GetComenzi(int userID)
        {
            Console.WriteLine("Before LINQ query");
            var comenziDetails = await (from c in _dbContext.Comanda
                                        join p in _dbContext.Produs on c.ProdusID equals p.ID
                                        join u in _dbContext.User on c.UserID equals u.ID
                                        where u.ID == userID
                                        select new ComandaDetails
                                        {
                                            UserName = u.UserName,
                                            NumeUser = u.Nume,
                                            NumeProdus = p.Nume,
                                            Cantitate = c.cantitate,
                                            CostProd = p.Pret * c.cantitate
                                        }).ToListAsync();
            Console.WriteLine("After LINQ query");
            Console.WriteLine(comenziDetails);

            return comenziDetails;
        }
    }
}
