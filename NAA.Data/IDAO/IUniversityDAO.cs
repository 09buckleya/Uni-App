using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NAA.Data.Models.Domain;
using NAA.Data.Repository;
namespace NAA.Data.IDAO
{
    public interface IUniversityDAO
    {
        void RemoveApplicationFromCollection(Application application, University university, NAAContext context);
        void AddApplicationToCollection(Application application, int universityId, NAAContext context);
        University GetUniversity(Application application, NAAContext context);
        IList<University> GetUniversities(NAAContext context);
    }
}
