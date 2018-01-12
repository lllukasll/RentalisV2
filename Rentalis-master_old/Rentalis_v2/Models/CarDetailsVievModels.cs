using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rentalis_v2.Models
{
    public class CarDetailsVievModels
    {
        public CarModels car { get; set; }
        public byte IsAvailible { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public DateTime DateFromDT { get; set; }
        public DateTime DateToDT { get; set; }
    }
}