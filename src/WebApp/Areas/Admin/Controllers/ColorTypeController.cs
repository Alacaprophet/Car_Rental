using Application.Services;
using Application.Services.Concrete;
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
    public class ColorTypeController : Controller
    {
       
        private IColorTypeService ColorService { get; set; }
        public ColorTypeController(IColorTypeService service)
        {
            ColorService = service;

        }
        public ActionResult Index()
        {
            ColorTypeFilter filter = new ColorTypeFilter();
            filter.Name = "";
            var item = ColorService.Get(filter);
            return View(item);
        }

        // GET: ColorTypeController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: ColorTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ColorTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ColorType color)
        {
            try
            {
                Response respons= ColorService.Add(color);
                ViewBag.response = respons;
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ColorTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            var item = ColorService.GetById(id);
            return View(item);
        }

        // POST: ColorTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ColorType color)
        {
            try
            {
                Response response = ColorService.Update(color);
                ViewBag.response = response;
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ColorTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            var item = ColorService.GetById(id);
            return View(item);
        }

        // POST: ColorTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //int id, IFormCollection collection
        public ActionResult Delete(ColorType color)
        {
            try
            {
                Response response = ColorService.Delete(color.Id);
                ViewBag.response = response;
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
