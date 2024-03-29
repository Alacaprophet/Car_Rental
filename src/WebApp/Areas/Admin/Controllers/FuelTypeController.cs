﻿using Application.Services.Concrete;
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
    [Route("admin/[controller]/[action]")]
    public class FuelTypeController : Controller
    {
        private IFuelTypeService fuelTypeService { get; set; }
        public FuelTypeController(IFuelTypeService iFuelTypeService)
        {
            fuelTypeService = iFuelTypeService;
        }
        // GET: FuelTypeController
        public ActionResult Index()
        {
            FuelTypeFilter filter = new FuelTypeFilter();
            filter.Name = "";
            List<FuelType> list = fuelTypeService.Get(filter);
            return View(list);
        }

        // GET: FuelTypeController/Details/5
        //public ActionResult Details(int id)
        //{
           
        //    return View(item);
        //}

        // GET: FuelTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FuelTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FuelType fuelType)
        {
            try
            {
                Response response = fuelTypeService.Add(fuelType);
                ViewBag.Response = response;
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: FuelTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            var item = fuelTypeService.GetById(id);
            return View(item);
        }

        // POST: FuelTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FuelType fuelType)
        {
            try
            {
                Response response = fuelTypeService.Update(fuelType);
                ViewBag.Response = response;
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: FuelTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            var item = fuelTypeService.GetById(id);

            return View(item);
        }

        // POST: FuelTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(FuelType fuel)
        {
            try
            {
                Response response = fuelTypeService.Delete(fuel.Id);
                ViewBag.Response = response;
                return RedirectToAction("Index"); ;
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
