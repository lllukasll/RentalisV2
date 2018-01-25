using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using Rentalis_v2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MySql.Data.MySqlClient;
using PagedList;

namespace Rentalis_v2.Controllers
{
    
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;

        public AdminController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Admin
        [Authorize(Roles = "SuperAdmin,Admin")]
        public ActionResult Index()
        {
            var viewModel = new IndexAdminViewModel();
            viewModel.cars = _context.carModels
                .OrderByDescending(p => p.ProductionYear);
            viewModel.services = _context.carServices.ToList();
            viewModel.users = _context.Users.ToList();
            return View(viewModel);
        }

        [Authorize(Roles = "SuperAdmin,Admin")]
        public ActionResult Cars(int? page)
        {
            var cars = from p in _context.carModels
                         select p;

            cars = cars.OrderBy(p => p.Name);
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(cars.ToPagedList(pageNumber, pageSize));
        }

        [Authorize(Roles = "SuperAdmin,Admin")]
        public ActionResult AddCar()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public ActionResult SaveCar(CarModels car)
        {
            if (!ModelState.IsValid)
            {
                return View("AddCar", car);
            }

            HttpPostedFileBase file = Request.Files["ImageData"];
            car.Image = ConvertToBytes(file);

            var NewCar = new CarModels
            {
                Id = car.Id,
                Name = car.Name,
                Description = car.Description,
                ShortDescription = car.ShortDescription,
                ProductionYear = car.ProductionYear,
                Image = car.Image,

                Abs = car.Abs,
                AirBags = car.AirBags,
                PowerSteering = car.PowerSteering,
                AirConditioning = car.AirConditioning,
                CentralLocking = car.CentralLocking,

                Doors = car.Doors,
                Seets = car.Seets,
                GearBox = car.GearBox,
                FuelType = car.FuelType,
                Type = car.Type,

                PricePerDay = car.PricePerDay,
                PlateNumber = car.PlateNumber
            };

            if (car.Id == null)
            {
                _context.carModels.Add(NewCar);
            }
            else
            {
                var carInDb = _context.carModels.Single(c => c.Id == car.Id);
                carInDb.Name = NewCar.Name;
                carInDb.Description = NewCar.Description;
                carInDb.ShortDescription = NewCar.ShortDescription;
                carInDb.ProductionYear = NewCar.ProductionYear;
                carInDb.Image = NewCar.Image;

                carInDb.Abs = NewCar.Abs;
                carInDb.AirBags = NewCar.AirBags;
                carInDb.PowerSteering = NewCar.PowerSteering;
                carInDb.AirConditioning = NewCar.AirConditioning;
                carInDb.CentralLocking = NewCar.CentralLocking;

                carInDb.Doors = NewCar.Doors;
                carInDb.Seets = NewCar.Seets;
                carInDb.GearBox = NewCar.GearBox;
                carInDb.FuelType = NewCar.FuelType;
                carInDb.Type = NewCar.Type;

                carInDb.PricePerDay = NewCar.PricePerDay;
                carInDb.PlateNumber = NewCar.PlateNumber;
            }

            _context.SaveChanges();

            return RedirectToAction("Cars");
        }

        public ActionResult RetrieveImage(int id)
        {
            byte[] cover = GetImageFromDataBase(id);
            if (cover != null)
            {
                return File(cover, "image/jpg");
            }
            else
            {
                return null;
            }
        }

        public byte[] GetImageFromDataBase(int Id)
        {
            var q = from temp in _context.carModels where temp.Id == Id select temp.Image;
            byte[] cover = q.First();
            return cover;
        }

        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }

        [Authorize(Roles = "SuperAdmin,Admin")]
        public ActionResult CarDetails(int id)
        {
            var car = _context.carModels.SingleOrDefault(c => c.Id == id);

            if (car == null)
                return HttpNotFound();

            return View(car);
        }

        [Authorize(Roles = "SuperAdmin,Admin")]
        public ActionResult EditCar(int id)
        {
            var car = _context.carModels.SingleOrDefault(c => c.Id == id);

            if (car == null)
                return HttpNotFound();

            return View("AddCar",car);
        }

        [Authorize(Roles = "SuperAdmin,Admin")]
        public ActionResult DeleteCar(int id)
        {
            var car = _context.carModels.SingleOrDefault(c => c.Id == id);

            if (car == null)
                return HttpNotFound();

            return View(car);
        }

        [Authorize(Roles = "SuperAdmin,Admin")]
        public ActionResult DeleteCarFromDb(CarModels car)
        {
            var carInDb = _context.carModels.Single(c => c.Id == car.Id);

            _context.carModels.Remove(carInDb);
            _context.SaveChanges();

            return RedirectToAction("Cars");
        }

        [Authorize(Roles = "SuperAdmin,Admin")]
        public ActionResult Bookings(int? page)
        {
           
            var bookings = from p in _context.bookingModels
                           .Include(p=>p.OrderStatusId)
                         select p;

            bookings = bookings.OrderBy(p => p.userId);
            int pageSize = 2;
            int pageNumber = (page ?? 1);
            return View(bookings.ToPagedList(pageNumber, pageSize));
        }

        [Authorize(Roles = "SuperAdmin,Admin")]
        public ActionResult BokkingDetails(int id)
        {
            BookingDetailsViewModel booking = new BookingDetailsViewModel();

            booking.bookingModel = _context.bookingModels.Include(c => c.OrderStatusId).Include(d => d.CarModel).Single(c => c.Id == id);
            var statusList = _context.orderStatusModels.ToList();
            List<SelectListItem> test = new List<SelectListItem>();
            foreach (var status in statusList)
            {
                test.Add(new SelectListItem
                {
                    Text = status.name,
                    Value = status.id.ToString()
                });
            }

            booking.orderStatus = test;

            //var booking = _context.bookingModels.Include(c => c.OrderStatusId).Single(c => c.Id == id);

            return View(booking);
        }

        [Authorize(Roles = "SuperAdmin,Admin")]
        public ActionResult UpdateStatus(BookingDetailsViewModel booking)
        {
            var order = _context.bookingModels.Include(c => c.OrderStatusId).Single(c => c.Id == booking.bookingModel.Id);

            order.OrderStatusId = _context.orderStatusModels.Single(c => c.id == booking.bookingModel.OrderStatusId.id);

            _context.SaveChanges();

            return RedirectToAction("Bookings");
        }

        [Authorize(Roles = "SuperAdmin,Admin")]
        public ActionResult Users(int? page)
        {
            //var users = _context.Users.ToList();

            var usersWithRoles = (from user in _context.Users
                from userRole in user.Roles
                join role in _context.Roles on userRole.RoleId equals
                role.Id
                select new UsersViewModel()
                {
                    UserId = user.Id,
                    Username = user.UserName,
                    Email = user.Email,
                    Role = role.Name
                }).ToList();
            int pageSize = 2;
            int pageNumber = (page ?? 1);
            return View(usersWithRoles.ToPagedList(pageNumber, pageSize));
            
        }

        [Authorize(Roles = "SuperAdmin,Admin")]
        public ActionResult UserDetails(string userId)
        {

            var rolesList = _context.Roles.ToList();
            List<SelectListItem> roles = new List<SelectListItem>();
            foreach (var role in rolesList)
            {
                roles.Add(new SelectListItem
                {
                    Text = role.Name,
                    Value = role.Id
                });
            }

            var userWithRoles = (from user in _context.Users
                from userRole in user.Roles
                join role in _context.Roles on userRole.RoleId equals
                role.Id where user.Id == userId
                select new AdminUserDetailsViewModel()
                {
                    userId = user.Id,
                    userName = user.UserName,
                    email = user.Email,
                    RoleId = role.Id,
                }).Single();

            AdminUserDetailsViewModel userDetails = new AdminUserDetailsViewModel();
            userDetails = userWithRoles;
            userDetails.RoleList = roles;

            return View(userDetails);
        }

        [Authorize(Roles = "SuperAdmin,Admin")]
        public ActionResult UpdateUserRole(/*string userId, string roleId*/AdminUserDetailsViewModel userDetails)
        {

            string query = String.Format(@"UPDATE aspnetuserroles SET RoleId='{0}' WHERE UserId LIKE '{1}'",userDetails.RoleId, userDetails.userId);

            MySqlConnection conn = new MySqlConnection("SERVER=localhost;DATABASE=rentalisv2;UID=root;PASSWORD=;");
            try
            {
                using (MySqlCommand cmdDatabase = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    cmdDatabase.ExecuteNonQuery();

                    return RedirectToAction("Users");
                }
            }
            catch 
            {
                return HttpNotFound();
            }

        }

        [Authorize(Roles = "SuperAdmin,Admin")]
        public ActionResult AddUser()
        {
            return View();
        }
        //[HttpPost, ActionName("DeleteCar")]
        //public ActionResult DeleteCar(int id)
        //{
        //    return RedirectToAction("Cars");
        //}
    }
}