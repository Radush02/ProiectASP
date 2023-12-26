using Microsoft.AspNetCore.Mvc;
using TemaASP.Data;

namespace TemaASP.Controllers
{
    public class ProdusController : Controller
    {
        private readonly ApplicationDBContext _context;
        public ProdusController(ApplicationDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var produse = _context.Produs.ToList();

            return View(produse);
        }
    }
}
