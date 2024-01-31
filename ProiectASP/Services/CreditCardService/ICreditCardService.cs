using ProiectASP.Models;
using ProiectASP.Models.DTOs;

namespace ProiectASP.Services.CreditCardService
{
    public interface ICreditCardService
    {
        Task<IEnumerable<CreditCardAllDTO>> GetCreditCards(string userName);
        Task AddCreditCard(CreditCardDTO cc, string username);
        Task DeleteCreditCard(int id);
    }
}
