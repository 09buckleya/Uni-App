using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NAA.Data.Models.Domain;
namespace NAA.Services.IService
{
    public interface IApplicationService
    {
        void DeleteApplication(int applicationId);
        void AddApplication(Application application, string userId, int universityId, string course);
        Application GetApplication(int applicationId);
        void GoFirm(int applicationId);
        //Web service
        List<Application> GetApplications(int universityId);
        void GiveOffer(string offer, int applicationId);
    }
}
