using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NAA.Data.DAO;
using NAA.Data.IDAO;
using NAA.Data.Models.Domain;
using NAA.Data.Repository;
using NAA.Services.IService;
namespace NAA.Services.Service
{
    public class ApplicationService : IApplicationService
    {
        private IApplicationDAO applicationDAO;
        private IUserDAO userDAO;
        private IUniversityDAO universityDAO;
        public ApplicationService()
        {
            applicationDAO = new ApplicationDAO();
            userDAO = new UserDAO();
            universityDAO = new UniversityDAO();
        }
        public void DeleteApplication(int applicationId)
        {
            using (var context = new NAAContext())
            {
                Application application = context.Applications.Find(applicationId);
                University university = universityDAO.GetUniversity(application, context);
                universityDAO.RemoveApplicationFromCollection(application, university, context);
                User user = userDAO.GetUser(application, context);
                userDAO.RemoveApplicationFromCollection(application, user, context);
                applicationDAO.DeleteApplication(application, context);
            }
        }
        public void AddApplication(Application application, string userId, int universityId, string course)
        {
            Application newApplication = new Application()
            {
                Course = course,
                Statement = application.Statement,
                TeacherContact = application.TeacherContact,
                TeacherReference = null,
                Offer = null,
                Firm = false,
            };
            using (var context = new NAAContext())
            {
                applicationDAO.AddApplication(newApplication, context);
                userDAO.AddApplicationToCollection(newApplication, userId, context);
                universityDAO.AddApplicationToCollection(newApplication, universityId, context);
            }
        }
        public Application GetApplication(int applicationId)
        {
            using (var context = new NAAContext())
            {
                return applicationDAO.GetApplication(applicationId, context);
            }
        }
        public void GoFirm(int applicationId)
        {
            using (var context = new NAAContext())
            {
                Application application = applicationDAO.GetApplication(applicationId, context);
                application.Firm = true;
                applicationDAO.GiveOffer(application, context);
            }
        }
        //Web Service
        public List<Application> GetApplications(int universityId)
        {
            using (var context = new NAAContext())
            {
                return applicationDAO.GetApplications(universityId, context);
            }
        }
        public void GiveOffer(string offer, int applicationId)
        {
            using (var context = new NAAContext())
            {
                Application application = applicationDAO.GetApplication(applicationId, context);
                application.Offer = offer;
                applicationDAO.GiveOffer(application, context);
            }
        }
    }
}
