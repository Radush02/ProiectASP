using Microsoft.AspNetCore.Mvc;
using ProiectASP.Models.DTOs;
using ProiectASP.Models;
using ProiectASP.Services.CreditCardService;

namespace ProiectASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        private readonly ICreditCardService _ccservice;

        public CreditCardController(ICreditCardService service)
        {
            _ccservice = service;
        }
        [HttpGet("{username}")]
        public async Task<IEnumerable<CreditCardAllDTO>> GetCreditCards(string username)
        {
            return await _ccservice.GetCreditCards(username);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCreditCard(int id)
        {
            try
            {
                await _ccservice.DeleteCreditCard(id);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }
        [HttpPost]
        public async Task<IActionResult> AddCreditCard(CreditCardDTO cc,string username)
        {
            await _ccservice.AddCreditCard(cc,username);
            return Ok();
        }

    }
}