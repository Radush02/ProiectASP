using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProiectASP.Exceptions;
using ProiectASP.Models;
using ProiectASP.Services.ProdusService;
using ProiectASP.Models.DTOs.ProdusDTOs;

namespace ProiectASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProdusController : ControllerBase
    {
        private readonly IProdusServices _produsServices;

        public ProdusController(IProdusServices produsServices)
        {
            _produsServices = produsServices;
        }

        [HttpPost,Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateProdus([FromForm] ProdusPozaDTO p)
        {
            Console.WriteLine(p.produs.Nume);
            await _produsServices.CreateProdus(p.produs,p.poza);
            return Ok();
        }

        [HttpDelete("{ProdusId}"),Authorize(Roles ="Admin")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteProdus(int ProdusId)
        {
/*            var claims = HttpContext.User.Claims.Select(c => $"{c.Type}: {c.Value}").ToList();
            Console.WriteLine("Claims: " + string.Join(", ", claims));*/
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

        [HttpGet,AllowAnonymous]
        public async Task<IEnumerable<ProdusLinkDTO>> GetAllProduse()
        {
            return await _produsServices.GetAllProduse();
        }

        [HttpGet("{ProdusId}"), AllowAnonymous]
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

        [HttpGet("nume/{NumeProdus}"), AllowAnonymous]
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

        [HttpPut, Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateProdus([FromBody] ProdusDTO produs)
        {
            await _produsServices.UpdateProdus(produs);
            return Ok();
        }
    }
}
