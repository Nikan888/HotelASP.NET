using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Client> Clients { get; set; }
        public IEnumerable<Room> Rooms { get; set; }
        public IEnumerable<Worker> Workers { get; set; }
        public IEnumerable<ServiceViewModel> Services { get; set; }
    }
}
