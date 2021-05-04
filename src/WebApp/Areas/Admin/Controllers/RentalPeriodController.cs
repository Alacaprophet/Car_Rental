using Application.Services;
using Domain.DTOs;
using Domain.DTOs.Filter;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class RentalPeriodController : Controller
    {
        private IRentalPeriodService rentalPeriodService { get; set; }
        public RentalPeriodController(IRentalPeriodService service)
        {
            rentalPeriodService = service;
        }
        // GET: RentalPeriodController
        public ActionResult Index()
        {
            RentalPeriodFilter filter = new RentalPeriodFilter();
            filter.Name = "";
            List<RentalPeriod> list = rentalPeriodService.Get(filter);
            return View(list);
        }

        // GET: RentalPeriodController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: RentalPeriodController/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: RentalPeriodController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RentalPeriod rent)
        {
            try
            {
                Response response = rentalPeriodService.Add(rent);
                ViewBag.Response = response;
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: RentalPeriodController/Edit/5
        public ActionResult Edit(int id)
        {
            var item = rentalPeriodService.GetById(id);
            return View(item);
        }

        // POST: RentalPeriodController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RentalPeriod rent)
        {
            try
            {
                Response response = rentalPeriodService.Update(rent);
                ViewBag.Response = response;
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: RentalPeriodController/Delete/5
        public ActionResult Delete(int id)
        {
            var item = rentalPeriodService.GetById(id);
            return View(item);
        }

        // POST: RentalPeriodController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(RentalPeriod rent)
        {
            try
            {
                Response response = rentalPeriodService.Delete(rent);
                ViewBag.Response = response;
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
