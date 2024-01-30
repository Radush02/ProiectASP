using Amazon.S3.Model;
using ProiectASP.Models;
using ProiectASP.Models.DTOs.ProdusDTOs;

namespace ProiectASP.Services.ProdusService
{
    public interface IProdusServices
    {
         Task<IEnumerable<ProdusLinkDTO>> GetAllProduse();
         Task<ProdusLinkDTO> GetProdusById(int ProdusId);
        Task<ProdusLinkDTO> GetProdusByNume(string NumeProdus);
        Task CreateProdus(ProdusDTO produs, IFormFile poza);
         Task UpdateProdus(ProdusDTO Produs);
         Task DeleteProdus(int ProdusId);


    }
}
