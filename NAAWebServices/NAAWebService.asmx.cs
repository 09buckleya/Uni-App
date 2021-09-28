using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using NAA.OutServices.IService;
using NAA.OutServices.Models;
using NAA.OutServices.Service;
namespace NAAWebServices
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
        IContract service;
        public NAAWebService()
        {
            service = new Service();
        }

        [WebMethod]
        public Category[] GetApplicants()
        {
            return service.GetApplicants();
        }
    }
}
