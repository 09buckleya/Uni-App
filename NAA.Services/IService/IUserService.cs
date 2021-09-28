using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NAA.Data.Models.Domain;
namespace NAA.Services.IService
{
    public interface IUserService
    {
        User GetUserByEmail(string email);
        IList<Application> GetApplications(string userId);
        IList<User> GetUsers();
        void UpdateUser(User user, string userId);
        void DeleteUser(string userId);
        void AddUser(User user);
        User GetUser(string userId);
    }
}
