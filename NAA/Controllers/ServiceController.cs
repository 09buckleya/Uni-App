using NAA.InServices.IService;
using NAA.InServices.Service;
using System.Web.Mvc;
namespace NAA.Controllers
{
    public class ServiceController : Controller
    {
        IInboundService service;
        public ServiceController()
        {
            service = new InboundService();
        }
        public ActionResult GetShefCourses(string userId, int universityId)
        {
            ViewBag.userId = userId;
            ViewBag.universityId = universityId;
            return View(service.GetShefCourses());
        }
        public ActionResult GetSHUCourses(string userId, int universityId)
        {
            ViewBag.userId = userId;
            ViewBag.universityId = universityId;
            return View(service.GetSHUCourses());
        }
    }
}