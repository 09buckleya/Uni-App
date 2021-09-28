using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NAA.Data.Models.Domain;
using NAA.Services.IService;
using NAA.Services.Service;
namespace NAA.Controllers
{
    public class ApplicationController : Controller
    {
        IApplicationService applicationService;
        public ApplicationController()
        {
            applicationService = new ApplicationService();
        }
        // GET: Application
        public ActionResult GoFirm(int applicationId)
        {
            applicationService.GoFirm(applicationId);
            return RedirectToAction("GetUser", "User");
        }
        public ActionResult Test()
        {
            int universityId = 2;
            return View(applicationService.GetApplications(universityId));
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: Application/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Application/Create
        public ActionResult AddApplication(string userId, int universityId, string course)
        {
            ViewBag.userId = userId;
            ViewBag.universityId = universityId;
            ViewBag.course = course;
            return View();
        }

        // POST: Application/Create
        [HttpPost]
        public ActionResult AddApplication(Application application, string userId, int universityId, string course)
        {
            try
            {
                // TODO: Add insert logic here
                applicationService.AddApplication(application, userId, universityId, course);
                return RedirectToAction("GetUser", "User");
            }
            catch
            {
                return View();
            }
        }

        // GET: Application/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Application/Edit/5
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

        // GET: Application/Delete/5
        public ActionResult DeleteApplication(int applicationId)
        {
            return View(applicationService.GetApplication(applicationId));
        }

        // POST: Application/Delete/5
        [HttpPost]
        public ActionResult DeleteApplication(int applicationId, Application application)
        {
            try
            {
                // TODO: Add delete logic here
                applicationService.DeleteApplication(applicationId);
                return RedirectToAction("GetUser", "User");
            }
            catch
            {
                return View();
            }
        }
    }
}
