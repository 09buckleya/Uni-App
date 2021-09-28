using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NAA.Data.Models.Domain;
using NAA.Data.Repository;
namespace NAA.Data.IDAO
{
    public interface IUserDAO
    {
        User GetUserByEmail(string email, NAAContext context);
        void RemoveApplicationFromCollection(Application application, User user, NAAContext context);
        void AddApplicationToCollection(Application application, string userId, NAAContext context);
        IList<Application> GetApplications(string userId, NAAContext context);
        IList<User> GetUsers(NAAContext context);
        void UpdateUser(User user, NAAContext context);
        void DeleteUser(User user, NAAContext context);
        void AddUser(User user, NAAContext context);
        User GetUser(Application application, NAAContext context);
        User GetUser(string userId, NAAContext context);
    }
}
