
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProiectASP.Data;
using ProiectASP.Exceptions;
using ProiectASP.Models;
using ProiectASP.Models.DTOs;

namespace ProiectASP.Repositories
{
    public class ComandaRepository :IComandaRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public ComandaRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Comanda>> GetAllComenzi()
        {
            return await Task.FromResult(_dbContext.Comanda.Include(u => u.Users).ThenInclude(a => a.AdreseLivrare).Include(p => p.Produse).ToList());
        }
        public async Task<IEnumerable<Comanda>> GetComandabyId(int userId)
        {
            var comanda = await _dbContext.Comanda.Where(c => c.UserID == userId).ToListAsync();

            if (comanda == null)
            {
                throw new NotFoundException($"User-ul cu ID-ul {userId} nu a dat vreo comanda.");
            }
            return comanda;
        }
        public async Task CreateComanda(IEnumerable<Comanda> comanda)
        {
            foreach(var c in comanda)
                _dbContext.Comanda.Add(c);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateComanda(Comanda comanda)
        {
            _dbContext.Comanda.Update(comanda);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteComanda(int comandaId)
        {
            var comandaToRemove = await _dbContext.Comanda.Where(u => u.ID == comandaId).ToListAsync();

            if (comandaToRemove == null)
            {
                throw new NotFoundException($"Nu exista comanda cu ID-ul {comandaId}.");
            }

            if (comandaToRemove != null)
            {
                foreach (var c in comandaToRemove)
                    _dbContext.Comanda.Remove(c);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
