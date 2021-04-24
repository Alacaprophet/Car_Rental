﻿using Application.Services;
using Application.Services.Concrete;
using Domain.DTOs.Filter;
using Domain.Entities;
using Domain.Enums;
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
    public class VehicleRentalPriceController : Controller
    {
        public IVehicleRentalPriceService RentalPriceService { get; set; }
        public VehicleRentalPriceController(IVehicleRentalPriceService service)
        {
            RentalPriceService = service;
        }
        // GET: VehicleRentalPriceController
        public ActionResult Index()
        {
            VehicleRentalPriceFilter filter = new VehicleRentalPriceFilter();
            List<VehicleRentalPriceTable> list = RentalPriceService.Get(filter);
            return View(list);
        }

        // GET: VehicleRentalPriceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VehicleRentalPriceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleRentalPriceController/Create
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

        // GET: VehicleRentalPriceController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VehicleRentalPriceController/Edit/5
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

        // GET: VehicleRentalPriceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VehicleRentalPriceController/Delete/5
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