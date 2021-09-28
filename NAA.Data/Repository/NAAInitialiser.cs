using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NAA.Data.Models.Domain;
namespace NAA.Data.Repository
{
    public class NAAInitialiser : System.Data.Entity.DropCreateDatabaseIfModelChanges<NAAContext>
    {
        protected override void Seed(NAAContext context)
        {
            User user = new User();
            user.UserId = "owen";
            user.Name = "Owen";
            user.Address = "64 Zoo Lane";
            user.Phone = "0800 00 1066";
            user.Email = "Owen@shu.ac.uk";
            context.Users.Add(user);

            context.SaveChanges();
        }
    }
}
