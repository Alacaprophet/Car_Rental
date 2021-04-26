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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
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
            filter.Name = "";
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

            ViewBag.VehicleBrands = GetVehicleBrand();
            return View();
        }
        private List<SelectListItem> GetVehicleBrand()
        {
            return VehicleBrandService.Get(new VehicleBrandFilter()).Select(b => new SelectListItem(b.Name, b.Id.ToString())).ToList();
        }
        // POST: VehicleModelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehicleModel vehicleModel)
        {
            try
            {
                if (vehicleModel.Name == null)
                {
                    ViewBag.Response = Domain.DTOs.Response.Fail("Adı alanı boş bırakılamaz");
                    return View();
                }
                var response = VehicleModelService.Add(vehicleModel);
                ViewBag.Response = response;
             
            }
            catch
            {
                ViewBag.Response = Domain.DTOs.Response.Fail("Bir Hata oluştu");
            }
            finally
            {

                ViewBag.VehicleBrands = GetVehicleBrand();
            }
            return View();
        }

        // GET: VehicleModelController/Edit/5
        public ActionResult Edit(int id)
        {
            var item = VehicleModelService.GetById(id);
            ViewBag.VehicleBrands = GetVehicleBrand();
            return View(item);
        }

        // POST: VehicleModelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VehicleModel vehicleModel)
        {
            try
            {
                Response response = VehicleModelService.Update(vehicleModel);
                ViewBag.Response = response;
            }
            catch
            {

                ViewBag.Response = Domain.DTOs.Response.Fail("Bir Hata oluştu");
            }
            finally
            {

                ViewBag.VehicleBrands = GetVehicleBrand();
            }
            return View(vehicleModel);
        }

        // GET: VehicleModelController/Delete/5
        public ActionResult Delete(int id)
        {
            var item = VehicleModelService.GetDetail(id);
            return View(item);
        }

        // POST: VehicleModelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Response response = VehicleModelService.Delete(id);
                ViewBag.Response = response;
            }
            catch
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
