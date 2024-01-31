using ProiectASP.Models;

namespace ProiectASP.Repositories.CreditCardRepository
{
    public interface ICreditCardRepository
    {
        Task AddCreditCard(CreditCard creditCard);
        Task<IEnumerable<CreditCard>> GetCreditCards(int userID);
        Task DeleteCreditCard(int userID);

    }
}
