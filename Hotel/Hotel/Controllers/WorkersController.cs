using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel.Data;
using Hotel.Infrastructure.Filters;

namespace Hotel.Controllers
{
    [TypeFilter(typeof(TimingLogAttribute))]
    public class WorkersController : Controller
    {
        private readonly HotelContext _context;

        public WorkersController(HotelContext context)
        {
            _context = context;
        }

        // GET: Workers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Workers.ToListAsync());
        }
    }
}
