using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NAA.InServices.IService;
using NAA.InServices.ProxyToHallamWebService;
using NAA.InServices.ProxyToSheffieldWebService;
namespace NAA.InServices.Service
{
    
    public class InboundService : IInboundService
    {
        SHUWebServiceSoapClient shuProxy;
        SheffieldWebServiceSoapClient sheffProxy;
        public InboundService()
        {
            shuProxy = new SHUWebServiceSoapClient("SHUWebServiceSoap", "http://webteach_net.hallam.shu.ac.uk/cmsmr2/SHUWebService.asmx");
            sheffProxy = new SheffieldWebServiceSoapClient("SheffieldWebServiceSoap", "http://webteach_net.hallam.shu.ac.uk/cmsmr2/SheffieldWebService.asmx");
        }
        public IList<ShefCourse> GetShefCourses()
        {
            return sheffProxy.SheffCourses();
        }
        public IList<SHUCourse> GetSHUCourses()
        {
            return shuProxy.SheffCourses();
        }
    }
}
