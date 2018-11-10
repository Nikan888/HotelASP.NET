using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel.Data;
using Hotel.Infrastructure.Filters;

namespace Hotel.Controllers
{
    [TypeFilter(typeof(TimingLogAttribute))]
    public class ClientsController : Controller
    {
        private readonly HotelContext _context;

        public ClientsController(HotelContext context)
        {
            _context = context;
        }

        // GET: Clients
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clients.ToListAsync());
        }

    }
}
