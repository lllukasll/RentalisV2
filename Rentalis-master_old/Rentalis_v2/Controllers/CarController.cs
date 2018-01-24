using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Rentalis_v2.Models;
using MySql.Data.MySqlClient;

namespace Rentalis_v2.Controllers
{
    public class CarController : Controller
    {
        private ApplicationDbContext _context;

        public CarController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Car
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var car = _context.carModels.SingleOrDefault(c => c.Id == id);

            if (car == null)
                return HttpNotFound();

            CarDetailsVievModels carDetailsVievModel = new CarDetailsVievModels();
            carDetailsVievModel.car = car;
            

            return View(carDetailsVievModel);
        }

        [HttpPost]
        public ActionResult Details(int id, DateTime dateFrom, DateTime dateTo)
        {
            string dT = dateTo.ToString("yyyyMMddhhmmss");
            string dF = dateFrom.ToString("yyyyMMddhhmmss");

            var car = _context.carModels.SingleOrDefault(c => c.Id == id);

            if (car == null)
                return HttpNotFound();

            CarDetailsVievModels carDetailsVievModel = new CarDetailsVievModels();
            carDetailsVievModel.car = car;
            carDetailsVievModel.DateFrom = dF;
            carDetailsVievModel.DateTo = dT;
            carDetailsVievModel.DateFromDT = dateFrom;
            carDetailsVievModel.DateToDT = dateTo;
            

            string query = String.Format(@"SELECT * FROM rentalisv2.bookingmodels B WHERE carId = {0} AND ({1} >= DateTimeFrom AND {1} <=DateTimeTo) OR ({2} >= DateTimeFrom AND {2} <= DateTimeTo) ;",id.ToString(), dF, dT);

            MySqlConnection conn = new MySqlConnection("SERVER=localhost;DATABASE=rentalisv2;UID=root;PASSWORD=;");
            try
            {
                using (MySqlCommand cmdDatabase = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    MySqlDataReader reader = cmdDatabase.ExecuteReader();
                    if (reader.HasRows)
                    {
                        carDetailsVievModel.IsAvailible = 1;
                    }
                    else
                    {
                        //CarRentViewModels carRentViewModel = new CarRentViewModels();
                        //carRentViewModel.car = car;
                        //carRentViewModel.dateFrom = dateFrom;
                        //carRentViewModel.dateTo = dateTo;
                        //return View("Rent", carRentViewModel);

                        carDetailsVievModel.IsAvailible = 2;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return View(carDetailsVievModel);
        }

        [HttpGet]
        public ActionResult Rent(int id,DateTime DateFrom, DateTime DateTo)
        {
            var car = _context.carModels.SingleOrDefault(c => c.Id == id);

            if (car == null)
                return HttpNotFound();

            CarRentViewModels carRentViewModel = new CarRentViewModels();
            carRentViewModel.car = car;
            carRentViewModel.dateFrom = DateFrom;
            carRentViewModel.dateTo = DateTo;
            carRentViewModel.days = Math.Ceiling((DateTo - DateFrom).TotalDays);
            carRentViewModel.TotalPrice = car.PricePerDay * carRentViewModel.days;

            carRentViewModel.PaymentMethod = new List<SelectListItem>();

            carRentViewModel.PaymentMethod.Add(new SelectListItem{Text = "Opłata przy odbiorze", Value = "1"});
            carRentViewModel.PaymentMethod.Add(new SelectListItem{Text = "Płatność online", Value = "2"});

            return View(carRentViewModel);
        }

        public ActionResult ConfirmRent(/*int id, DateTime DateFrom, DateTime DateTo, double TotalPrice, string userId, int paymentMethod*/CarRentViewModels rentModel)
        {
            //string dT = rentModel.dateTo.ToString("yyyyddMMHHmmss");
            //string dF = rentModel.dateFrom.ToString("yyyyddMMHHmmss");

            string dT = rentModel.YearTo + rentModel.MonthTo.PadLeft(2,'0') + rentModel.DayTo.PadLeft(2, '0') + rentModel.HourTo.PadLeft(2, '0') + rentModel.MinuteTo.PadLeft(2, '0') +
                        rentModel.SecundTo.PadLeft(2, '0');
            string dF = rentModel.YearFrom + rentModel.MonthFrom.PadLeft(2, '0') + rentModel.DayFrom.PadLeft(2, '0') + rentModel.HourFrom.PadLeft(2, '0') + rentModel.MinuteFrom.PadLeft(2, '0') +
                        rentModel.SecundFrom.PadLeft(2, '0');

            if (rentModel.ChoosenPaymentMethod == 1)
            {
                
            }else if (rentModel.ChoosenPaymentMethod == 2)
            {
                
            }

            string query = String.Format(@"INSERT INTO rentalisv2.bookingmodels VALUES (null,'{0}','{1}','{2}',{3},{4},1)", rentModel.car.Id, rentModel.userId, dF,dT, rentModel.TotalPrice);
            //INSERT INTO rentalisv2.bookingmodels VALUES (null,'20171010080000','20171020080000',300,'asdasdas-eeq123-dxczcc.ad',2);
            MySqlConnection conn = new MySqlConnection("SERVER=localhost;DATABASE=rentalisv2;UID=root;PASSWORD=;");
            try
            {
                using (MySqlCommand cmdDatabase = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    cmdDatabase.ExecuteNonQuery();

                    return View("CorrectlyRented");
                }
            }
            catch 
            {
                return HttpNotFound();

            }

        }

        public ActionResult CorrectlyRented()
        {
            return View();
        }

    }
}