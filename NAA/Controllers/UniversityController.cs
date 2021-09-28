using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NAA.Services.IService;
using NAA.Services.Service;
namespace NAA.Controllers
{
    public class UniversityController : Controller
    {
        IUniversityService universityService;
        public UniversityController()
        {
            universityService = new UniversityService();
        }
        public ActionResult GetUniversities(string userId)
        {
            ViewBag.userId = userId;
            return View(universityService.GetUniversities());
        }
        // GET: University
        public ActionResult Index()
        {
            return View();
        }

        // GET: University/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: University/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: University/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: University/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: University/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: University/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: University/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
