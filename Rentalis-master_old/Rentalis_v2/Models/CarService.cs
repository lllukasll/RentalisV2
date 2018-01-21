using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rentalis_v2.Models
{
    public class CarService
    {
        public int Id { get; set; }

        [StringLength(100, ErrorMessage = "Nie może być więcej znaków niż 100")]
        [Required(ErrorMessage = "Pole Nazwa nie może być puste")]
        public string serviceName { get; set; }

        [Required(ErrorMessage = "Pole Nazwa nie może być puste")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Pole Nazwa nie może być puste")]
        public DateTime DateTime { get; set; }
        [Required(ErrorMessage = "Pole Nazwa nie może być puste")]
        public int LengthService { get; set; }

        public virtual CarModels CarModel { get; set; }
       


    }
}