using ProiectASP.Models;

namespace ProiectASP.Repositories.CreditCardRepository
{
    public interface ICreditCardRepository
    {
        Task AddCreditCard(CreditCard creditCard);

    }
}
