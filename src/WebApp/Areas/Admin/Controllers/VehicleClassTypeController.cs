using Application.Services;
using Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTOs.Filter;
using Domain.Entities;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class VehicleClassTypeController : Controller
    {
        private IVehicleClassTypeService VehicleClassTypeService { get; }
        public VehicleClassTypeController(IVehicleClassTypeService service)
        {
            VehicleClassTypeService = service;
        }
        // GET: VehicleClassTypeController
        public ActionResult Index()
        {
            VehicleClassTypeFilter filter = new VehicleClassTypeFilter();
            filter.Name = "";
            var item = VehicleClassTypeService.Get(filter);
            return View(item);
        }

        // GET: VehicleClassTypeController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: VehicleClassTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleClassTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehicleClassType vehicleClassType)
        {
            try
            {
                Response response = VehicleClassTypeService.Add(vehicleClassType);
                ViewBag.Response = response;
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicleClassTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            VehicleClassType EditToVehicleClass = VehicleClassTypeService.GetById(id);
            return View(EditToVehicleClass);
        }

        // POST: VehicleClassTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VehicleClassType vehicleClassType)
        {
            try
            {
                Response response = VehicleClassTypeService.Update(vehicleClassType);
                ViewBag.Response = response;
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicleClassTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            VehicleClassType DeleteToVehicleClass = VehicleClassTypeService.GetById(id);
            return View(DeleteToVehicleClass);
        }

        // POST: VehicleClassTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(VehicleClassType vehicleClassType)
        {
            try
            {
                Response response = VehicleClassTypeService.Delete(vehicleClassType);
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
