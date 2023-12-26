using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProiectASP.Data;
using ProiectASP.Models;

namespace ProiectASP.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProdusController : Controller
    {
        private readonly ApplicationDBContext _context;
        public ProdusController(ApplicationDBContext context)
        {
            _context = context;
        }
 
    }
}
