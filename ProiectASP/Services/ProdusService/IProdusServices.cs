using ProiectASP.Models;

namespace ProiectASP.Services.ProdusService
{
    public interface IProdusServices
    {
         Task<IEnumerable<Produs>> GetAllProduse();
         Task<Produs> GetProdusById(int ProdusId);
        Task<Produs> GetProdusByNume(string NumeProdus);
         Task CreateProdus(Produs Produs);
         Task UpdateProdus(Produs Produs);
         Task DeleteProdus(int ProdusId);
        
    }
}
