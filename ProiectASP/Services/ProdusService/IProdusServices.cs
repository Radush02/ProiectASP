using ProiectASP.Models;
using ProiectASP.Models.DTOs;

namespace ProiectASP.Services.ProdusService
{
    public interface IProdusServices
    {
         Task<IEnumerable<ProdusDTO>> GetAllProduse();
         Task<Produs> GetProdusById(int ProdusId);
        Task<Produs> GetProdusByNume(string NumeProdus);
         Task CreateProdus(ProdusDTO Produs);
         Task UpdateProdus(Produs Produs);
         Task DeleteProdus(int ProdusId);
        
    }
}
