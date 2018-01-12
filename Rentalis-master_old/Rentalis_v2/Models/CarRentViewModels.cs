using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rentalis_v2.Models
{
    public class CarRentViewModels
    {
        public CarModels car { get; set; }
        public DateTime dateFrom { get; set; }
        public DateTime dateTo { get; set; }
        public double days { get; set; }
        public double TotalPrice { get; set; }
        public int sum { get; set; }
    }
}