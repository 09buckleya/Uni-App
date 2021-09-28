using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

using NAA.Data.Models.Domain;
using NAA.Services.IService;
using NAA.Services.Service;
namespace NAA.Controllers
{
    [RequireHttps]
    public class UserController : Controller
    {
        IUserService userService;
        // GET: User
        public  UserController()
        {
            userService = new UserService();
        }
        public ActionResult GetApplications(string userId)
        {
            return View(userService.GetApplications(userId));
        }
        public ActionResult GetUser(string userId)
        {
            userId = User.Identity.GetUserId();
            return View(userService.GetUser(userId));
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult AddUser()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult AddUser(User user)
        {
            try
            {
                // TODO: Add insert logic here
                userService.AddUser(user);

                return RedirectToAction("GetUser", "User");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult UpdateUser(string userId)
        {
            User user = userService.GetUser(userId);
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult UpdateUser(string userId, User user)
         {
            try
            {
                // TODO: Add update logic here
                userService.UpdateUser(user, userId);
                return RedirectToAction("GetUser", "User", new { id = user.UserId });
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
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
