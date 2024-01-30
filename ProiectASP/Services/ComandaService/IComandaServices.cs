using ProiectASP.Models.DTOs;
using ProiectASP.Models;

namespace ProiectASP.Services.ComandaService
{
    public interface IComandaServices
    {
        Task<IEnumerable<ComandaDTO>> GetAllComenzi();
        Task<IEnumerable<ComandaDTO>> GetComandabyId(int userId);
        Task CreateComanda(IEnumerable<ComandaDTO> comanda);
        Task DeleteComanda(int comandaId);
    }
}
