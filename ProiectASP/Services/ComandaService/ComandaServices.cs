using Microsoft.EntityFrameworkCore;
using ProiectASP.Data;
using ProiectASP.Exceptions;
using ProiectASP.Models;
using ProiectASP.Repositories;

namespace ProiectASP.Services.ComandaService
{
    public class ComandaServices : IComandaServices
    {
        private readonly IComandaRepository _comandaRepository;
        private readonly ApplicationDBContext _dbContext;
        public ComandaServices(IComandaRepository comandaRepository,ApplicationDBContext dbContext)
        {
            _comandaRepository = comandaRepository;
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Comanda>> GetAllComenzi()
        {
            return await Task.FromResult(_dbContext.Comanda.Include(u=>u.Users).ThenInclude(a=>a.AdreseLivrare).Include(p=>p.Produse).ToList());
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
        public async Task CreateComanda(Comanda comanda)
        {
            _dbContext.Comanda.Add(comanda);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateComanda(Comanda comanda)
        {
            _dbContext.Comanda.Update(comanda);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<ComandaDetails>> GetComenzi(int userId)
        {
            var comenzi = await _comandaRepository.GetComenzi(userId);
            if (comenzi == null)
            {
                throw new NotFoundException("User-ul nu a dat vreo comanda.");
            }
            return comenzi;
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
