using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NAA.Data.Repository;
using NAA.Data.Models.Domain;
using NAA.Data.IDAO;
namespace NAA.Data.DAO
{
    public class UniversityDAO : IUniversityDAO
    {
        private NAAContext context;
        public UniversityDAO()
        {
            context = new NAAContext();
        }
        public void RemoveApplicationFromCollection(Application application, University university, NAAContext context)
        {
            context.Universities.Find(university.UniversityId).Applications.Remove(application);
            context.SaveChanges();
        }
        public void AddApplicationToCollection(Application application, int universityId, NAAContext context)
        {
            context.Universities.Find(universityId).Applications.Add(application);
            context.SaveChanges();
        }
        public University GetUniversity(Application application, NAAContext context)
        {
            IList<University> universities = GetUniversities(context);
            for (int i = 0; i < universities.Count; i++)
            {
                if (universities[i].Applications.Contains<Application>(application))
                {
                    return universities[i];
                }
            }
            return null;
        }
        public IList<University> GetUniversities(NAAContext context)
        {
            return context.Universities.ToList();
        }
    }
}
