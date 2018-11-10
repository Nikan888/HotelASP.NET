using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hotel.ViewModels
{
    public class ServicesViewModel
    {
        public IEnumerable<Service> Services { get; set; }

        //Свойство для фильтрации
        public ServiceViewModel ServiceViewModel { get; set; }
        //Свойство для навигации по страницам
        public PageViewModel PageViewModel { get; set; }
        //Список отчетных годов
        public SelectList ListYears { get; set; }
    }
}
