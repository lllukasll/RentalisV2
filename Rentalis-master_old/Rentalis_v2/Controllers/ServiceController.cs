using Rentalis_v2.Models;
using System;
using System.Collections.Generic;
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
        public ActionResult Index()
        {
            return View();
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
            var car = _context.carModels.Single(c => c.Id == viewModel.Car);
            var service = new CarService
            {
                serviceName = viewModel.serviceName,
                Description = viewModel.Description,
                FromDateTime = viewModel.FromDateTime,
                ToDateTime = viewModel.ToDateTime
            };
            _context.carServices.Add(service);
            _context.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }
        


        // GET: Service/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Service/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
