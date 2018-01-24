using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rentalis_v2.Models
{
    public class CarRentViewModels
    {
        public string userId { get; set; }
        public CarModels car { get; set; }
        public DateTime dateFrom { get; set; }
        public DateTime dateTo { get; set; }
        public double days { get; set; }
        public double TotalPrice { get; set; }
        public int sum { get; set; }
        public int ChoosenPaymentMethod { get; set; }
        public List<SelectListItem> PaymentMethod { get; set; }
       
        public string YearFrom { get; set; }
        public string MonthFrom { get; set; }
        public string DayFrom { get; set; }
        public string HourFrom { get; set; }
        public string MinuteFrom { get; set; }
        public string SecundFrom { get; set; }

        public string YearTo { get; set; }
        public string MonthTo { get; set; }
        public string DayTo { get; set; }
        public string HourTo { get; set; }
        public string MinuteTo { get; set; }
        public string SecundTo { get; set; }
    }
}