using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProiectASP.Models.DTOs;
using ProiectASP.Exceptions;
using ProiectASP.Models;
using ProiectASP.Services.ProdusService;

namespace ProiectASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles="Admin")]
    public class ProdusController : ControllerBase
    {
        private readonly IProdusServices _produsServices;

        public ProdusController(IProdusServices produsServices)
        {
            _produsServices = produsServices;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProdus(ProdusDTO produs)
        {
            await _produsServices.CreateProdus(produs);
            return Ok();
        }

        [HttpDelete("{ProdusId}")]
        public async Task<IActionResult> DeleteProdus(int ProdusId)
        {
            try
            {
                await _produsServices.DeleteProdus(ProdusId);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IEnumerable<ProdusDTO>> GetAllProduse()
        {
            return await _produsServices.GetAllProduse();
        }

        [HttpGet("{ProdusId}")]
        public async Task<IActionResult> GetProdusById(int ProdusId)
        {
            try
            {
                var produs = await _produsServices.GetProdusById(ProdusId);
                return Ok(produs);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("nume/{NumeProdus}")]
        public async Task<IActionResult> GetProdusByNume(string NumeProdus)
        {
            try
            {
                var produs = await _produsServices.GetProdusByNume(NumeProdus);
                return Ok(produs);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProdus([FromBody] Produs produs)
        {
            await _produsServices.UpdateProdus(produs);
            return Ok();
        }
    }
}
