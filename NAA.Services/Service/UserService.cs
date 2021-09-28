using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NAA.Data.Models.Domain;
using NAA.Data.Repository;
using NAA.Data.IDAO;
using NAA.Data.DAO;
using NAA.Services.IService;

namespace NAA.Services.Service
{
    public class UserService : IUserService
    {
        private IUserDAO userDAO;
        public UserService()
        {
            userDAO = new UserDAO();
        }
        public User GetUserByEmail(string email)
        {
            using (var context = new NAAContext())
            {
                return userDAO.GetUserByEmail(email, context);
            }
        }
        public IList<Application> GetApplications(string userId)
        {
            using (var context = new NAAContext())
            {
                return userDAO.GetApplications(userId, context);
            }
        }
        public IList<User> GetUsers()
        {
            using (var context = new NAAContext())
            {
                return userDAO.GetUsers(context);
            }
        }
        public void UpdateUser(User user, string userId)
        {
            using (var context = new NAAContext())
            {
                User _user = userDAO.GetUser(userId, context);
                _user.Name = user.Name;
                _user.Address = user.Address;
                _user.Phone = user.Phone;
                _user.Email = user.Email;
                userDAO.UpdateUser(_user, context);
                //User userToBeRemoved = userDAO.GetUser(userId, context);
            }
        }
        public void DeleteUser(string userId)
        {
            using (var context = new NAAContext())
            {
                User user = context.Users.Find(userId);
                userDAO.DeleteUser(user, context);
            }
        }
        public void AddUser(User user)
        {
            User newUser = new User()
            {
                Name = user.Name,
                Address = user.Address,
                Phone = user.Phone,
                Email = user.Email,
                UserId = user.UserId,
                
            };
            using (var context = new NAAContext())
            {
                
                userDAO.AddUser(newUser, context);
            }
        }
        public User GetUser(string userId)
        {
            using (var context = new NAAContext())
            {
                return userDAO.GetUser(userId, context);
            }
        }
    }
}
