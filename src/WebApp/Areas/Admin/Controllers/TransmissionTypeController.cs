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
    public class TransmissionTypeController : Controller
    {
        private ITransmissionTypeService TransmissionService { get; set; }
        public TransmissionTypeController(ITransmissionTypeService service)
        {
            TransmissionService = service;
        }
        public ActionResult Index()
        {
            TransmissionTypeFilter filter = new TransmissionTypeFilter();
            filter.Name = "";
            var item = TransmissionService.Get(filter);
            return View(item);
        }

        // GET: TransmissionTypeController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: TransmissionTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransmissionTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransmissionType transmissionType)
        {
            try
            {
                Response respons = TransmissionService.Add(transmissionType);
                ViewBag.Response = respons;
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: TransmissionTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            var item = TransmissionService.GetById(id);
            return View(item);
        }

        // POST: TransmissionTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TransmissionType transmissionType)
        {
            try
            {
                Response response = TransmissionService.Update(transmissionType);
                ViewBag.Response = response;
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: TransmissionTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            var item = TransmissionService.GetById(id);
            return View(item);
        }

        // POST: TransmissionTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TransmissionType transmissionType)
        {
            try
            {
                Response response = TransmissionService.Delete(transmissionType);
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
