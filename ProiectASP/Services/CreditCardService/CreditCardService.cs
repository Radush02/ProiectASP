using Microsoft.AspNetCore.Identity;
using ProiectASP.Models;
using ProiectASP.Models.DTOs;
using ProiectASP.Repositories;
using ProiectASP.Repositories.CreditCardRepository;
using System.Reflection.Metadata;

namespace ProiectASP.Services.CreditCardService
{
    public class CreditCardService:ICreditCardService
    {

        private readonly ICreditCardRepository _ccRepository;
        private readonly UserManager<User> _uRepository;
        public CreditCardService(ICreditCardRepository repository,UserManager<User> urepository)
        {
            _ccRepository = repository;
            _uRepository = urepository;
        }
        public async Task<IEnumerable<CreditCardAllDTO>> GetCreditCards(string username)
        {
            var user = await _uRepository.FindByNameAsync(username);
            var carduri = await _ccRepository.GetCreditCards(user.Id);
            var carduriDTO = new List<CreditCardAllDTO>();
            foreach(var c in carduri)
            {
                carduriDTO.Add(new CreditCardAllDTO()
                {
                    ID = c.ID,
                    NumarCard = c.NumarCard,
                    Data_Expirare = c.Data_Expirare,
                    CVV = c.CVV,
                });
            }
            return carduriDTO;
        }
        public async Task AddCreditCard(CreditCardDTO cc,string username)
        {
            var user = await _uRepository.FindByNameAsync(username);
            var creditCard = new CreditCard()
            {
                NumarCard = cc.NumarCard,
                Data_Expirare = cc.Data_Expirare,
                CVV = cc.CVV,
                userID = user.Id,
                Users = user
            };
            await _ccRepository.AddCreditCard(creditCard);
        }
        public async Task DeleteCreditCard(int id)
        {
            await _ccRepository.DeleteCreditCard(id);
        }
    }
}
