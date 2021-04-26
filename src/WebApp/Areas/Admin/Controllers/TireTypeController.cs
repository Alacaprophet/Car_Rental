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
    public class TireTypeController : Controller
    {
        private ITireTypeService TireTypeService { get; set; }
        
        public TireTypeController(ITireTypeService service)
        {
            TireTypeService = service;
        }
        // GET: TireTypeController

        public ActionResult Index()
        {
            TireTypeFilter filter = new TireTypeFilter();
            filter.Name = "";
            var list = TireTypeService.Get(filter);
            return View(list);
        }

        // GET: TireTypeController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: TireTypeController/Create
        public ActionResult Create()
        { 
            return View();
        }

        // POST: TireTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TireType tire)
        {
            try
            {

                Response response = TireTypeService.Add(tire);
                ViewBag.Response = response;
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: TireTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            TireType EditToTire = TireTypeService.GetById(id);
            return View(EditToTire);
        }

        // POST: TireTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TireType tire)
        {
            try
            {
                Response response = TireTypeService.Update(tire);
                ViewBag.Response = response;
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: TireTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            TireType DeleteToTire = TireTypeService.GetById(id);
            return View(DeleteToTire);
        }

        // POST: TireTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TireType tire)
        {
            try
            {

                Response response = TireTypeService.Delete(tire);
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
