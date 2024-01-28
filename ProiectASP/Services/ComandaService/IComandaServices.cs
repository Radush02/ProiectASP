using ProiectASP.Models;

namespace ProiectASP.Services.ComandaService
{
    public interface IComandaServices
    {
        Task<IEnumerable<Comanda>> GetAllComenzi();
        Task<IEnumerable<Comanda>> GetComandabyId(int userId);
        Task CreateComanda(Comanda comanda);
        Task UpdateComanda(Comanda comanda);
        Task DeleteComanda(int comandaId);

       // Task<IEnumerable<ComandaDetails>> GetComenzi(int userId);
    }
}
