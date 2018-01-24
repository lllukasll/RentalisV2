using Rentalis_v2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Rentalis_v2.Controllers
{
    public class ServiceController : Controller
    {
        private ApplicationDbContext _context;
        // GET: Service
        public ServiceController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index(/*string sortOrder, string currentFilter, int? page*/)
        {

            //ViewBag.CurrentSort = sortOrder;
            //ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            //ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            //var services = from p in _context.carServices
            //               select p;
            //services.Include(e => e.CarModel);
            //services = services.OrderBy(p => p.CarModel.Name);
            var services = _context.carServices
                .Include(a => a.CarModel);
            //switch (sortOrder)
            //{
            //    case "title_desc":
            //        services = services.OrderByDescending(p => p.serviceName);
            //        break;
            //    case "Date":
            //        services = services.OrderBy(p => p.CarModel.Name);
            //        break;
            //    case "date_desc":
            //        services= services.OrderByDescending(p => p.CarModel.Name);
            //        break;
            //    default:
            //        services = services.OrderBy(p => p.serviceName);
            //        break;

            //}
            //int pageSize = 5;
            //int pageNumber = (page ?? 1);
            //return View(services.ToPagedList(pageNumber, pageSize));

            return View(services);

          
        }

        // GET: Service/Details/5
        public ActionResult Details(int ?id)
        {

            if (id == null)
            {
                return HttpNotFound();
            }
            CarService service = _context.carServices.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // GET: Service/Create
        public ActionResult Create()
        {
            var viewModel = new ServiceCarViewModel
            {
                cars = _context.carModels.ToList()
             };
            return View(viewModel);
        }

        // POST: Service/Create
        [HttpPost]
        public ActionResult Create(ServiceCarViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.cars = _context.carModels.ToList();
                return View("Create",viewModel);
            }
            var car = _context.carModels.Single(c => c.Id == viewModel.Car);
            var service = new CarService
            {
                serviceName = viewModel.serviceName,
                Description = viewModel.Description,
                FromDateTime = viewModel.FromDateTime,
                ToDateTime = viewModel.ToDateTime,
                Price = viewModel.Price,
                CarModel = car
            };
            _context.carServices.Add(service);
            _context.SaveChanges();
            return RedirectToAction("Index", "Service");
        }
        


        // GET: Service/Edit/5
        public ActionResult Edit(int id)
        {
            var service = _context.carServices
                .Single(g => g.Id == id);
                

            var viewModel = new ServiceCarViewModel
            {
               
                cars = _context.carModels.ToList(),
                Id = service.Id,
                serviceName = service.serviceName,
                Description = service.Description,
                FromDateTime = service.FromDateTime,
                ToDateTime = service.FromDateTime,
                Price = service.Price

            };
            if (service == null)
                return HttpNotFound();

            return View(viewModel);
           
        }

        // POST: Service/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ServiceCarViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
               return View("Create", viewModel);
            }
            var car = _context.carModels.Single(c => c.Id == viewModel.Car);
            var service = _context.carServices.Single(e => e.Id == viewModel.Id);
            service.serviceName = viewModel.serviceName;
            service.Description = viewModel.Description;
            service.ToDateTime = viewModel.ToDateTime;
            service.FromDateTime = viewModel.FromDateTime;
            service.Price = viewModel.Price;
            service.CarModel.Id = viewModel.Car;


            _context.carServices.Add(service);
            _context.SaveChanges();
            return RedirectToAction("Index", "Service");
        }


        // GET: Service/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Service/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
