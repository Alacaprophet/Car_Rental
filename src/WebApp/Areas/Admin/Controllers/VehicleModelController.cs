using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTOs;
using Domain.DTOs.Filter;
using Domain.Entities;
namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]/[action]")]
    public class VehicleModelController : Controller
    {
      private IVehicleModelService VehicleModelService { get; }

        private IVehicleBrandService VehicleBrandService { get; }
        public VehicleModelController(IVehicleBrandService vehicleBrandService,IVehicleModelService vehicleModelService)
        {
            VehicleBrandService = vehicleBrandService;
            VehicleModelService = vehicleModelService;


        }
        public ActionResult Index()
        {
            VehicleModelFilter filter = new VehicleModelFilter();
            var items = VehicleModelService.Get(filter);
            return View(items);
        }
        // GET: VehicleModelController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VehicleModelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleModelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicleModelController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VehicleModelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicleModelController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VehicleModelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
