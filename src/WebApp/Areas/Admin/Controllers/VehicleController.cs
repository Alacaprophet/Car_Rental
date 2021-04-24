using Application.Services;
using Application.Services.Concrete;
using Domain.DTOs;
using Domain.DTOs.Filter;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class VehicleController : Controller
    {
        private IVehicleService VehicleService { get; set; }
        private IColorTypeService ColorTypeService { get; set; }

        private IFuelTypeService FuelTypeService { get; set; }
        private ITireTypeService TireTypeService { get; set; }
        private ITransmissionTypeService TransmissionTypeService { get; set; }
        private IVehicleBrandService VehicleBrandService { get; set; }
        private IVehicleClassTypeService VehicleClassTypeService { get; set; }
        private IVehicleModelService VehicleModelService { get; set; }
        
        public VehicleController(IVehicleService service, IColorTypeService colorTypeService, IFuelTypeService fuelTypeService, ITireTypeService tireTypeService, ITransmissionTypeService transmissionTypeService, IVehicleBrandService vehicleBrandService, IVehicleClassTypeService vehicleClassTypeService, IVehicleModelService vehicleModelService)
        {
            VehicleService = service;
            ColorTypeService = colorTypeService;
            FuelTypeService = fuelTypeService;
            TireTypeService = tireTypeService;
            TransmissionTypeService = transmissionTypeService;
            VehicleBrandService = vehicleBrandService;
            VehicleClassTypeService = vehicleClassTypeService;
            VehicleModelService = vehicleModelService;
        }
        // GET: VehicleController
        public ActionResult Index()
        {
            VehicleFilter filter = new VehicleFilter();
            List<VehicleDTO> list = VehicleService.Get(filter);
            return View(list);
        }

        // GET: VehicleController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}
        #region get dropdown items
        private List<SelectListItem> GetVehicleBrand()
        {
            VehicleBrandFilter filter = new VehicleBrandFilter();
            filter.Name = "";
            return VehicleBrandService.Get(filter).Select(b => new SelectListItem(b.Name, b.Id.ToString())).ToList();
        }
        private List<SelectListItem> GetVehicleModel()
        {
            VehicleModelFilter filter = new VehicleModelFilter();
            filter.Name = "";
            return VehicleModelService.Get(filter).Select(b => new SelectListItem(b.Name, b.Id.ToString())).ToList();
        }
        private List<SelectListItem> GetTransmissionType()
        {
            TransmissionTypeFilter filter = new TransmissionTypeFilter();
                filter.Name = "";
            return TransmissionTypeService.Get(filter).Select(b => new SelectListItem(b.Name, b.Id.ToString())).ToList();
        }
        private List<SelectListItem> GetFuelType()
        {
            FuelTypeFilter filter = new FuelTypeFilter();
            filter.Name = "";
            return FuelTypeService.Get(filter).Select(b => new SelectListItem(b.Name, b.Id.ToString())).ToList();
        }
        private List<SelectListItem> GetTireType()
        {
            TireTypeFilter filter = new TireTypeFilter();
            filter.Name = "";
            return TireTypeService.Get(filter).Select(b => new SelectListItem(b.Name, b.Id.ToString())).ToList();
        }
        private List<SelectListItem> GetVehicleClass()
        {
            VehicleClassTypeFilter filter = new VehicleClassTypeFilter();
            filter.Name = "";
            return VehicleClassTypeService.Get(filter).Select(b => new SelectListItem(b.Name, b.Id.ToString())).ToList();
        }
        private List<SelectListItem> GetColorType()
        {
            ColorTypeFilter filter = new ColorTypeFilter();
            filter.Name = "";
            return ColorTypeService.Get(filter).Select(b => new SelectListItem(b.Name, b.Id.ToString())).ToList();
        }
        
        #endregion
        // GET: VehicleController/Create
        public ActionResult Create()
        {
            DropdownViewBag();
            return View();
        }
        public void DropdownViewBag()
        {
            ViewBag.BrandName = GetVehicleBrand();
            ViewBag.ModelName = GetVehicleModel();
            ViewBag.Transmission = GetTransmissionType();
            ViewBag.Fuel = GetFuelType();
            ViewBag.Tire = GetTireType();
            ViewBag.ClassType = GetVehicleClass();
            ViewBag.ColorType = GetColorType();
        }
        // POST: VehicleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vehicle vehicle)
        {
            try
            {
                Response resp = VehicleService.Add(vehicle);
                ViewBag.Response = resp;
                DropdownViewBag();
                return View();
            }
            catch
            {
                DropdownViewBag();
                return View();
            }
        }

        // GET: VehicleController/Edit/5
        public ActionResult Edit(int id)
        {
            var item = VehicleService.GetById(id);
            DropdownViewBag();
            return View(item);
        }

        // POST: VehicleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Vehicle vehicle)
        {
            try
            {
                Response resp = VehicleService.Update(vehicle);
                ViewBag.Response = resp;
                DropdownViewBag();
                return View();
            }
            catch
            {
                DropdownViewBag();
                return View();
            }
        }

        // GET: VehicleController/Delete/5
        public ActionResult Delete(int id)
        {
            var deleting = VehicleService.GetDetails(id);
            return View(deleting);
        }

        // POST: VehicleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Vehicle vehicle)
        {
            try
            {
                Response resp = VehicleService.Delete(vehicle.Id);
                ViewBag.Response = resp;
                DropdownViewBag();
                return View();
            }
            catch
            {
                DropdownViewBag();
                return View();
            }
        }
    }
}
