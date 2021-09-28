using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NAA.Data.Models.Domain;
using NAA.Data.Repository;
namespace NAA.Data.IDAO
{
    public interface IApplicationDAO
    {
        void DeleteApplication(Application application, NAAContext context);
        void AddApplication(Application application, NAAContext context);
        IList<Application> GetApplications(NAAContext context);
        Application GetApplication(int applicationId, NAAContext context);
        void GoFirm(Application application, NAAContext context);
        //Web service
        List<Application> GetApplications(int universityId, NAAContext context);
        void GiveOffer(Application application, NAAContext context);
    }
}
