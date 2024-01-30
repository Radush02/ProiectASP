using ProiectASP.Models;
using ProiectASP.Models.DTOs.ProdusDTOs;

namespace ProiectASP.Repositories.ProdusRepository
{
    public interface IProdusRepository
    {
        Task CreateProdus(Produs p);
        Task<Produs> GetProdusByID(int ProdusId);
        Task DeleteProdus(Produs p);

        Task<IEnumerable<Produs>> ListProduse();
        Task<Produs> GetProdusByNume(string NumeProdus);
        Task UpdateProdus(Produs p);
    }
}
