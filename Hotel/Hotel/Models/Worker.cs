using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Worker
    {
        //ID сотрудника
        [Display(Name = "Код сотрудника")]
        public int WorkerID { get; set; }
        //ФИО сотрудника
        [Display(Name = "ФИО сотрудника")]
        public string WorkerFio { get; set; }
        //Должность сотрудника
        [Display(Name = "Должность сотрудника")]
        public string WorkerPost { get; set; }

        public ICollection<Service> Services { get; set; }

        public Worker()
        {
            Services = new List<Service>();
        }
    }
}
