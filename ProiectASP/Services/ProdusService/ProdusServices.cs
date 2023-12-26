using Microsoft.EntityFrameworkCore;
using ProiectASP.Data;
using ProiectASP.Exceptions;
using ProiectASP.Models;
using ProiectASP.Services;

namespace ProiectASP.Services.ProdusService
{
    public class ProdusServices : IProdusServices
    {
        private readonly ApplicationDBContext _dbContext;
        public ProdusServices(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateProdus(Produs produs)
        {
            _dbContext.Produs.Add(produs);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProdus(int ProdusId)
        {
            var produsToRemove = await _dbContext.Produs
                           .FirstOrDefaultAsync(u => u.ID == ProdusId);

            if (produsToRemove == null)
            {
                throw new NotFoundException($"Nu exista produs cu ID-ul {ProdusId}.");
            }

            if (produsToRemove != null)
            {
                _dbContext.Produs.Remove(produsToRemove);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Produs>> GetAllProduse()
        {
            return await Task.FromResult(_dbContext.Produs.ToList());
        }

        public async Task<Produs> GetProdusById(int ProdusId)
        {
            var produs = await _dbContext.Produs.FirstOrDefaultAsync(u => u.ID == ProdusId);

            if (produs == null){
                throw new NotFoundException($"Nu exista produs cu ID-ul {ProdusId}.");
            }
            return produs;
        }
        public async Task<Produs> GetProdusByNume(string NumeProdus)
        {
            var produs = await _dbContext.Produs.FirstOrDefaultAsync(u => u.Nume.ToUpper() == NumeProdus.ToUpper());

            if (produs == null){
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
