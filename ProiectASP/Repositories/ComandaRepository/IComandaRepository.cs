using ProiectASP.Models;
using ProiectASP.Models.DTOs;

namespace ProiectASP.Repositories { 
    public interface IComandaRepository
    {
        Task<IEnumerable<Comanda>> GetAllComenzi();
        Task<IEnumerable<Comanda>> GetComandabyId(int userId);
        Task CreateComanda(IEnumerable<Comanda> comanda);
        Task UpdateComanda(Comanda comanda);
        Task DeleteComanda(int comandaId);

        // Task<IEnumerable<ComandaDetails>> GetComenzi(int userId);
    }
}
