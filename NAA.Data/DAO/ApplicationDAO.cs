using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NAA.Data.IDAO;
using NAA.Data.Repository;
using NAA.Data.Models.Domain;
namespace NAA.Data.DAO
{
    public class ApplicationDAO : IApplicationDAO
    {
        private NAAContext context;
        public ApplicationDAO()
        {
            context = new NAAContext();
        }
        public void DeleteApplication(Application application, NAAContext context)
        {
            context.Applications.Remove(application);
            context.SaveChanges();
        }
        public void AddApplication(Application application, NAAContext context)
        {
            context.Applications.Add(application);
            context.SaveChanges();
        }
        public IList<Application> GetApplications(NAAContext context)
        {
            return context.Applications.ToList();
        }
        public Application GetApplication(int ApplicationId, NAAContext context )
        {
            return context.Applications.Find(ApplicationId);
        }
        public void GoFirm(Application application, NAAContext context)
        {
            Application applicationToUpdate = GetApplication(application.ApplicationId, context);
            if( applicationToUpdate.Offer == "U" || applicationToUpdate.Offer == "C")
            {
            context.Entry(applicationToUpdate).CurrentValues.SetValues(application);
            context.SaveChanges();
            }
        }
        public List<Application> GetApplications(int universityId, NAAContext context)
        {
            University university;
            university = context.Universities.Find(universityId);
            return context.Applications.ToList();
        }
        //public List<Application> GetApplications(int universityId, NAAContext context)
        //{
        //    IList<Application> applications;
        //    IList<Application> allApplications = GetApplications(context);
        //    for (int i = 0; i < allApplications.Count; i++)
        //    {
        //        if (allApplications[i].universityId)
        //    }
        //}
        public void GiveOffer(Application application, NAAContext context)
        {
            Application applicationToUpdate = GetApplication(application.ApplicationId, context);
            if(applicationToUpdate.Offer == "R" || applicationToUpdate.Offer == "U")
            {
                //Nothing should happen
            }
            if(applicationToUpdate.Offer == "C" || applicationToUpdate.Offer == "P" || applicationToUpdate.Offer is null)
            {
                context.Entry(applicationToUpdate).CurrentValues.SetValues(application);
                context.SaveChanges();
            }

        }
    }
}
