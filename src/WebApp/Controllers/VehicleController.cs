using Application.Services;
using Application.Services.Concrete;
using Domain.DTOs;
using Domain.DTOs.Filter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class VehicleController : Controller
    {
        private IColorTypeService ColorTypeService { get; set; }
        private IFuelTypeService FuelTypeService { get; set; }
        private ITireTypeService TireTypeService { get; set; }
        private ITransmissionTypeService TransmissionTypeService { get; set; }
        private IVehicleClassTypeService VehicleClassTypeService { get; set; }
        private IVehicleModelService VehicleModelService { get; set; }
        private IVehicleService VehicleService { get; set; }
        public IVehicleImageService VehicleImageService { get; set; }
        public IVehicleRentalPriceService VehicleRentalPriceService { get; set; }
        public VehicleController(IVehicleService service, IColorTypeService colorTypeService, IFuelTypeService fuelTypeService, ITireTypeService tireTypeService, ITransmissionTypeService transmissionTypeService, IVehicleBrandService vehicleBrandService, IVehicleClassTypeService vehicleClassTypeService, IVehicleModelService vehicleModelService, IVehicleImageService vehicleImageService, IVehicleRentalPriceService vehicleRentalPriceService)
        {
            VehicleService = service;
            ColorTypeService = colorTypeService;
            FuelTypeService = fuelTypeService;
            TireTypeService = tireTypeService;
            TransmissionTypeService = transmissionTypeService;
            VehicleClassTypeService = vehicleClassTypeService;
            VehicleModelService = vehicleModelService;
            VehicleImageService = vehicleImageService;
            VehicleRentalPriceService = vehicleRentalPriceService;
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
        public IActionResult Index()
        {
            VehicleFilter filter = new VehicleFilter();
            List<VehicleListItemDTO> list = VehicleService.GetListItems(filter);
            ViewBag.Vehicles = list;
            DropdownViewBag();
            return View(filter);
        }

        [HttpPost]
        public IActionResult Index(VehicleFilter filter)
        {
            List<VehicleListItemDTO> items = VehicleService.GetListItems(filter);
            ViewBag.Vehicles = items;
            DropdownViewBag();
            return View(filter);
        }
        public IActionResult Detail(int id)
        {
            VehicleDetailViewModel vehicleDetail = new VehicleDetailViewModel();
            vehicleDetail.Vehicle = VehicleService.GetDetail(id);
            vehicleDetail.VehicleImages = VehicleImageService.GetByVehicle(id);
            vehicleDetail.VehicleRentalPrices = VehicleRentalPriceService.Get(new VehicleRentalPriceFilter(id,DateTime.Today));
            ViewBag.VehicleDetail = vehicleDetail;
            return View();
        }
        public void DropdownViewBag()
        {
            ViewBag.ModelName = GetVehicleModel();
            ViewBag.Transmission = GetTransmissionType();
            ViewBag.Fuel = GetFuelType();
            ViewBag.Tire = GetTireType();
            ViewBag.ClassType = GetVehicleClass();
            ViewBag.ColorType = GetColorType();
        }
    }
}
