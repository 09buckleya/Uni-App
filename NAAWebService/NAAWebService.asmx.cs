using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using NAA.Data.Models.Domain;
using NAA.Services.IService;
using NAA.Services.Service;
//using NAA.OutServices.Service;
//using NAA.OutServices.Models;
//using NAA.OutServices.IService;
namespace NAAWebService
{
    /// <summary>
    /// Summary description for NAAWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class NAAWebService : System.Web.Services.WebService
    {
        IApplicationService service;
        public NAAWebService()
        {
            service = new ApplicationService();
        }
        //IContract service;
        //public NAAWebService()
        //{
        //    service = new Service();
        //}
        //[WebMethod]
        //public Category[] GetApplications()
        //{
        //    return service.GetApplicants();
        //}
        [WebMethod]
        public List<Application> GetApplications(int universityId)
        {
            return service.GetApplications(universityId);
        }
        [WebMethod]
        public Application GetApplication(int applicationId)
        {
            return service.GetApplication(applicationId);
        }
        [WebMethod]
        public void GiveOffer(int applicationId, string offer)
        {
            service.GiveOffer(offer, applicationId);
        }
    }
}
