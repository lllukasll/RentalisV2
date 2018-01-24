using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rentalis_v2.Models
{
    public class BookingModels
    {
        public int? Id { get; set; }

        public int carId { get; set; }

        public string userId { get; set; }

        public double TotalPrice { get; set; }

        public DateTime DateTimeFrom { get; set; }

        public DateTime DateTimeTo { get; set; }

        public int PaymentMethod { get; set; }

        public OrderStatusModel OrderStatusId { get; set; }
    }
}