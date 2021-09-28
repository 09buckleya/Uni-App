using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using NAA.Data.Repository;
using NAA.Data.Models.Domain;
using NAA.Data.IDAO;
namespace NAA.Data.DAO
{
    public class UserDAO : IUserDAO
    {
        private NAAContext context;
        public UserDAO()
        {
            context = new NAAContext();
        }
        public User GetUserByEmail(string email, NAAContext context)
        {
            IQueryable<User> user = from u in context.Users where u.Email == email select u;
            return user.ToList().First();
        }
        public void RemoveApplicationFromCollection(Application application, User user, NAAContext context)
        {
            context.Users.Find(user.UserId).Applications.Remove(application);
            context.SaveChanges();
        }
        public void AddApplicationToCollection(Application application, string userId, NAAContext context)
        {
            context.Users.Find(userId).Applications.Add(application);
            context.SaveChanges();
        }
        public IList<Application> GetApplications(string userId, NAAContext context)
        {
            User user;
            user = context.Users.Find(userId);
            return context.Applications.ToList();
        }
        public IList<User> GetUsers(NAAContext context)
        {
            return context.Users.ToList();
        }
        public void UpdateUser(User user, NAAContext context)
        {
            User productToUpdate = GetUser(user.UserId, context);
            context.Entry(productToUpdate).CurrentValues.SetValues(user);
            context.SaveChanges();
        }
        public void DeleteUser(User user, NAAContext context)
        {
            context.Users.Remove(user);
            context.SaveChanges();
        }
        public void AddUser(User user, NAAContext context)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }
        public User GetUser(Application application, NAAContext context)
        {
            IList<User> users = GetUsers(context);
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Applications.Contains<Application>(application))
                {
                    return users[i];
                }
            }
            return null;
        }
        public User GetUser(string userId, NAAContext context)
        {
            context.Users.Include(g => g.Applications).ToList();
            return context.Users.Find(userId);
        }
    }
}
