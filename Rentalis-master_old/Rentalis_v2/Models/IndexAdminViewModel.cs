using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rentalis_v2.Models
{
    public class IndexAdminViewModel
    {
        public IEnumerable<CarModels> cars { get; set; }
        public IEnumerable<CarService> services { get; set; }
        public IEnumerable<ApplicationUser> users { get; set; }
    }
}