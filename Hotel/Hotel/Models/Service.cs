﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class Service
    {
        //ID услуги
        [Key]
        [Display(Name = "Код услуги")]
        public int ServiceID { get; set; }
        //Название услуги
        [Display(Name = "Название услуги")]
        public string ServiceName { get; set; }
        //Описание услуги
        [Display(Name = "Описание услуги")]
        public string ServiceDescription { get; set; }
        //Дата въезда
        [Display(Name = "Дата въезда")]
        [DataType(DataType.Date)]
        public DateTime EntryDate { get; set; }
        //Дата выезда
        [Display(Name = "Дата выезда")]
        [DataType(DataType.Date)]
        public DateTime DepartureDate { get; set; }

        //ID клиента
        [Display(Name = "Код клиента")]
        public int? ClientID { get; set; }
        //ID сотрудника
        [Display(Name = "Код сотрудника")]
        public int? WorkerID { get; set; }
        //ID номера
        [Display(Name = "Код номера")]
        public int? RoomID { get; set; }

        //ссылка на клиентов
        public virtual Client Client { get; set; }
        //ссылка на номера
        public virtual Room Room { get; set; }
        //сслыка на сотрудников
        public virtual Worker Worker { get; set; }
    }
}
