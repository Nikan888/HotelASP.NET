using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Hotel.ViewModels;
using Hotel.Data;
using Hotel.Infrastructure.Filters;

namespace Hotel.Controllers
{
    [ExceptionFilter]
    [TypeFilter(typeof(TimingLogAttribute))]
    public class HomeController : Controller
    {
        private HotelContext _db;
        public HomeController(HotelContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var clients = _db.Clients.Take(10).ToList();
            var rooms = _db.Rooms.Take(10).ToList();
            var workers = _db.Workers.Take(10).ToList();
            List<ServiceViewModel> services = _db.Services
                .OrderByDescending(d => d.EntryDate)
                .Select(t => new ServiceViewModel { ServiceID = t.ServiceID, ServiceName = t.ServiceName, ServiceDescription = t.ServiceDescription, EntryDate = t.EntryDate, DepartureDate = t.DepartureDate, ClientFio = t.Client.ClientFio, RoomType = t.Room.RoomType, WorkerFio = t.Worker.WorkerFio })
                .Take(10)
                .ToList();

            HomeViewModel homeViewModel = new HomeViewModel { Clients = clients, Rooms = rooms, Workers = workers, Services = services };
            return View(homeViewModel);
        }
    }
}
