using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel.Data;
using Hotel.ViewModels;
using Hotel.Infrastructure.Filters;
using Hotel.Infrastructure;
using System;
using Hotel.Models;

namespace Hotel.Controllers
{
    [TypeFilter(typeof(TimingLogAttribute))] // Фильтр ресурсов
    [ExceptionFilter] // Фильтр исключений
    public class ServicesController : Controller
    {
        private readonly HotelContext _context;
        private ServiceViewModel _service = new ServiceViewModel
        {
            ServiceName = "",
            ServiceDescription = "",
            ClientFio = "",
            RoomType = "",
            WorkerFio = ""
        };

        public ServicesController(HotelContext context)
        {
            _context = context;
        }

        // GET: Services
        [SetToSession("SortState")] //Фильтр действий для сохранение в сессию состояния сортировки
        public IActionResult Index(SortState sortOrder)
        {
            // Считывание данных из сессии
            var sessionService = HttpContext.Session.Get("Service");
            var sessionSortState = HttpContext.Session.Get("SortState");
            if (sessionService != null)
                _service = Transformations.DictionaryToObject<ServiceViewModel>(sessionService);
            if ((sessionSortState != null))
                if ((sessionSortState.Count > 0) & (sortOrder == SortState.No)) sortOrder = (SortState)Enum.Parse(typeof(SortState), sessionSortState["sortOrder"]);

            // Сортировка и фильтрация данных
            IQueryable<Service> hotelContext = _context.Services;
            hotelContext = Sort_Search(hotelContext, sortOrder, _service.RoomType ?? "", _service.ClientFio ?? "");

            // Формирование модели для передачи представлению
            _service.SortViewModel = new SortViewModel(sortOrder);
            ServicesViewModel services = new ServicesViewModel
            {
                Services = hotelContext,
                ServiceViewModel = _service
            };
            return View(services);
        }
        // Post: Services
        [HttpPost]
        [SetToSession("Service")] //Фильтр действий для сохранение в сессию параметров отбора
        public IActionResult Index(ServiceViewModel service)
        {
            // Считывание данных из сессии
            var sessionSortState = HttpContext.Session.Get("SortState");
            var sortOrder = new SortState();
            if (sessionSortState.Count > 0)
                sortOrder = (SortState)Enum.Parse(typeof(SortState), sessionSortState["sortOrder"]);

            // Сортировка и фильтрация данных
            IQueryable<Service> hotelContext = _context.Services;
            hotelContext = Sort_Search(hotelContext, sortOrder, service.RoomType ?? "", service.ClientFio ?? "");

            // Формирование модели для передачи представлению
            service.SortViewModel = new SortViewModel(sortOrder);
            ServicesViewModel services = new ServicesViewModel
            {
                Services = hotelContext,
                ServiceViewModel = service
            };

            return View(services);
        }
        // Сортировка и фильтрация данных
        private IQueryable<Service> Sort_Search(IQueryable<Service> services, SortState sortOrder, string searchRoomType, string searchClientFio)
        {
            switch (sortOrder)
            {
                case SortState.RoomTypeAsc:
                    services = services.OrderBy(s => s.Room.RoomType);
                    break;
                case SortState.RoomTypeDesc:
                    services = services.OrderByDescending(s => s.Room.RoomType);
                    break;
                case SortState.ClientFioAsc:
                    services = services.OrderBy(s => s.Client.ClientFio);
                    break;
                case SortState.ClientFioDesc:
                    services = services.OrderByDescending(s => s.Client.ClientFio);
                    break;
            }
            services = services.Include(o => o.Room).Include(o => o.Client)
                .Where(o => o.Room.RoomType.Contains(searchRoomType ?? "")
                & o.Client.ClientFio.Contains(searchClientFio ?? ""));

            
            return services;
        }
    }
}
