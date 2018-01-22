using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Rentalis_v2.Models
{
    public class BookingDetailsViewModel
    {
        public BookingModels bookingModel { get; set; }
        public List<SelectListItem> orderStatus { get; set; }
        //public List<string> orderStatus { get; set; }
    }
}