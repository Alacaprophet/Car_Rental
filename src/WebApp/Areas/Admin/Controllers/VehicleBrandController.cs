using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services;
using Domain.DTOs.Filter;
using Domain.Entities;
using Domain.DTOs;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]/[action]")]
    public class VehicleBrandController : Controller
    {
        private IVehicleBrandService VehicleBrandService { get; }
        public VehicleBrandController(IVehicleBrandService vehicle)
        {
            VehicleBrandService = vehicle;
        }
        // GET: VehicleBrandController
        public ActionResult Index()
        {
            VehicleBrandFilter filter = new VehicleBrandFilter();
            filter.Name = "";
            var items = VehicleBrandService.Get(filter);
            return View(items);
        }

        // GET: VehicleBrandController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VehicleBrandController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleBrandController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehicleBrand vehicleBrand)
        {
            try
            {
                Response response =VehicleBrandService.Add(vehicleBrand);
              
                
               ViewBag.Response = response;
               
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicleBrandController/Edit/5
        public ActionResult Edit(int id)
        {
            var item = VehicleBrandService.GetById(id);
            return View(item);
        }

        // POST: VehicleBrandController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VehicleBrand vehicleBrand)
        {
            try
            {
               Response resp= VehicleBrandService.Update(vehicleBrand);
                ViewBag.Response = resp;
                return View(vehicleBrand);
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicleBrandController/Delete/5
        public ActionResult Delete(int id)
        {
            var item = VehicleBrandService.GetById(id);
            return View(item);
        }

        // POST: VehicleBrandController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
               Response resp= VehicleBrandService.Delete(id);
                if (resp.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var item = VehicleBrandService.GetById(id);
                    ViewBag.Response = resp;
                    return View(item);
                }
                ViewBag.Response = resp;
                return View();
            }
            catch
            {
                ViewBag.Response = Domain.DTOs.Response.Fail("Bir hata oluştu");
                var item = VehicleBrandService.GetById(id);
                return View();
            }
        }
    }
}
