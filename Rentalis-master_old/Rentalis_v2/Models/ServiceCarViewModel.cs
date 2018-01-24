using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rentalis_v2.Models
{
    public class ServiceCarViewModel
    {
        public int Id { get; set; }
        public string serviceName { get; set; }
        public string Description { get; set; }
        
       
        public DateTime FromDateTime { get; set; }
        public DateTime ToDateTime { get; set; }
        public decimal Price { get; set; }

        public int Car { get; set; }
        public IEnumerable<CarModels> cars { get; set; }
    }
}