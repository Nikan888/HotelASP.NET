using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Client
    {
        //ID клиента
        [Display(Name = "Код клиента")]
        public int ClientID { get; set; }
        //ФИО клиента
        [Display(Name = "ФИО")]
        public string ClientFio { get; set; }
        //Пасспортные данные клиента
        [Display(Name = "Пасспортные данные")]
        public string ClientPassportData { get; set; }

        public virtual ICollection<Service> Services { get; set; }

        public Client()
        {
            Services = new List<Service>();

        }
    }
}
