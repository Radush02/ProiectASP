using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProiectASP.Exceptions;
using ProiectASP.Models;
using ProiectASP.Services.ComandaService;

namespace ProiectASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComandaController : ControllerBase
    {
        private readonly IComandaServices _comandaServices;

        public ComandaController(IComandaServices comandaServices)
        {
            _comandaServices = comandaServices;
        }

        [HttpGet]
        public async Task<IEnumerable<Comanda>> GetAllComenzi()
        {
            return await _comandaServices.GetAllComenzi();
        }

/*        [HttpGet("{userId}")]
        public async Task<IActionResult> GetComandabyId(int userId)
        {
            try
            {
                var comenzi = await _comandaServices.GetComandabyId(userId);
                return Ok(comenzi);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }*/

        [HttpPost]
        public async Task<IActionResult> CreateComanda([FromBody] Comanda comanda)
        {
            await _comandaServices.CreateComanda(comanda);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComanda([FromBody] Comanda comanda)
        {
            await _comandaServices.UpdateComanda(comanda);
            return Ok();
        }

        [HttpDelete("{comandaId}")]
        public async Task<IActionResult> DeleteComanda(int comandaId)
        {
            try
            {
                await _comandaServices.DeleteComanda(comandaId);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
/*        [HttpGet("{userId}")]
        public async Task<IActionResult> GetComenzi(int userId)
        {
            try
            {
                var comenzi = await _comandaServices.GetComenzi(userId);
                return Ok(comenzi);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }*/
    }
}
