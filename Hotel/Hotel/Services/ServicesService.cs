using Hotel.Data;
using Hotel.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Hotel.Services
{
    // Класс выборки 10 записей из всех таблиц 
    public class ServicesService
    {
        private HotelContext _context;
        public ServicesService(HotelContext context)
        {
            _context = context;
        }
        public HomeViewModel GetHomeViewModel()
        {
            var clients = _context.Clients.Take(10).ToList();
            var rooms = _context.Rooms.Take(10).ToList();
            var workers = _context.Workers.Take(10).ToList();
            List<ServiceViewModel> services = _context.Services
                .OrderByDescending(d => d.EntryDate)
                .Select(t => new ServiceViewModel
                {
                    ServiceID = t.ServiceID,
                    ServiceName = t.ServiceName,
                    ServiceDescription = t.ServiceDescription,
                    EntryDate = t.EntryDate,
                    DepartureDate = t.DepartureDate,
                    ClientFio = t.Client.ClientFio,
                    RoomType = t.Room.RoomType,
                    WorkerFio = t.Worker.WorkerFio
                })
                .Take(10)
                .ToList();

            HomeViewModel homeViewModel = new HomeViewModel
            {
                Clients = clients,
                Rooms = rooms,
                Workers = workers,
                Services = services
            };
            return homeViewModel;
        }
    }
}
