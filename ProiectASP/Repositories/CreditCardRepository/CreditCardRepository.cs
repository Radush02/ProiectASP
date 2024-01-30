using Microsoft.EntityFrameworkCore;
using ProiectASP.Data;
using ProiectASP.Models;


namespace ProiectASP.Repositories.CreditCardRepository
{
    public class CreditCardRepository:ICreditCardRepository
    {
       private readonly ApplicationDBContext _dbcontext;
       public CreditCardRepository(ApplicationDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
       public async Task AddCreditCard(CreditCard creditCard)
        {
            await _dbcontext.CreditCard.AddAsync(creditCard);
            await _dbcontext.SaveChangesAsync();
        }
        public async Task<IEnumerable<CreditCard>> GetCreditCards(int userID)
        {
            
            return await _dbcontext.CreditCard.Where(x => x.userID == userID).ToListAsync();

        }
        public async Task DeleteCreditCard(int id)
        {
            var k = await _dbcontext.CreditCard.Where(x => x.ID == id).FirstOrDefaultAsync();
            if (k!=null)
                _dbcontext.CreditCard.Remove(k);
            
            await _dbcontext.SaveChangesAsync();
        }
    }
}
