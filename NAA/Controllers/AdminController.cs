using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NAA.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
namespace NAA.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {

        ApplicationDbContext context;
        public AdminController()
        {
            context = new ApplicationDbContext();
        }
        public ActionResult AdminPage()
        {
            return View();
        }
        public ActionResult GetUsers()
        {
            return View(context.Users.ToList());
        }
        public ActionResult GetRoles()
        {
            return View(context.Roles.ToList());
        }
        public ActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddRole(FormCollection collection)
        {
            IdentityRole role = new IdentityRole(collection["RoleName"]);
            context.Roles.Add(role);
            context.SaveChanges();
            return RedirectToAction("GetRoles");
        }
        //public ActionResult DeleteRole()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult DeleteRole(FormCollection collection)
        //{
        //    IdentityRole role = new IdentityRole(collection["RoleName"]);
        //    context.Roles.Remove(role);
        //    context.SaveChanges();
        //    return RedirectToAction("GetRoles");
        //}
        public ActionResult GetRolesForUser()
        {
            var userList = context.Users.OrderBy(u => u.UserName).ToList().Select(
                uu => new SelectListItem
                {
                    Value = uu.UserName.ToString(),
                    Text = uu.UserName
                }).ToList();
            ViewBag.Users = userList;
            return View();
        }
        [HttpPost]
        public ActionResult GetRolesForUser(string userName)
        {
            ApplicationUser user = context.Users.Where(u => u.UserName.Equals
            (userName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            ViewBag.userRoles = um.GetRoles(user.Id);
            return View("GetRolesForUserConfirmed");
        }
        public ActionResult ManageUserRoles()
        {
            var userList = context.Users.OrderBy(
                u => u.UserName).ToList().Select(
                uu => new SelectListItem
                {
                    Value = uu.UserName.ToString(),
                    Text = uu.UserName
                }).ToList();
            ViewBag.Users = userList;
            var roleList = context.Roles.OrderBy(
                r => r.Name).ToList().Select(
                rr => new SelectListItem
                {
                    Value = rr.Name.ToString(),
                    Text = rr.Name
                }).ToList();
            ViewBag.Roles = roleList;
            return View();
        }
        [HttpPost]
        public ActionResult ManageUserRoles(string userName, string roleName)
        {
            ApplicationUser user =
                context.Users.Where
                (u => u.UserName.Equals(userName,
                    StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var um = new UserManager<ApplicationUser>
                (new UserStore<ApplicationUser>(context));
            var idResult = um.AddToRole(user.Id, roleName);

            var roleList = context.Roles.OrderBy
                (r => r.Name).ToList().Select
                (rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = roleList;
            var userList = context.Users.OrderBy
                (u => u.UserName).ToList().Select
                (uu => new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();
            ViewBag.Users = userList;
            return View("ManageUserRoles");
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}