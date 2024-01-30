using Microsoft.EntityFrameworkCore;
using ProiectASP.Data;
using ProiectASP.Exceptions;
using ProiectASP.Models;

namespace ProiectASP.Repositories.ProdusRepository
{
    public class ProdusRepository:IProdusRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public ProdusRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateProdus(Produs p)
        {
            _dbContext.Produs.Add(p);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteProdus(Produs p)
        {
            _dbContext.Produs.Remove(p);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<Produs> GetProdusByID(int ProdusId)
        {
          var p = await _dbContext.Produs.FirstOrDefaultAsync(u => u.ID == ProdusId);
            if (p == null)
            {
                throw new NotFoundException($"Nu exista produs cu ID-ul {ProdusId}.");
            }
            return p;
        }
        public async Task<IEnumerable<Produs>> ListProduse()
        {
            return await Task.FromResult(_dbContext.Produs.ToList());
        }
        public async Task<Produs> GetProdusByNume(string NumeProdus)
        {
            var produs = await _dbContext.Produs.Where(p=>p.Nume.ToUpper().Contains(NumeProdus.ToUpper())).FirstOrDefaultAsync();

            if (produs == null)
            {
                throw new NotFoundException($"Nu exista produs cu numele {NumeProdus}.");
            }
            return produs;
        }
        public async Task UpdateProdus(Produs produs)
        {
            _dbContext.Produs.Update(produs);
            await _dbContext.SaveChangesAsync();
        }
    }   
}
