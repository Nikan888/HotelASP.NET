using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Worker
    {
        public int WorkerID { get; set; }
        public string WorkerFIO { get; set; }
        public string WorkerPost { get; set; }

        public ICollection<Service> Services { get; set; }
    }
}
