using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAccessApp.BackEnd
{
    public class UserAccess
    {
        public List<users> GetAllUsers()
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.users.ToList();
            }
        }

        public users GetUserByUsername(string username)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.users.SingleOrDefault(t => t.username == username);
            }
        }

        public void CreateNewUser(users newUser)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                db.users.Add(newUser);
                db.SaveChanges();
            }
        }

        public void DeleteUserByUsername(string username)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                var userToDelete = db.users.SingleOrDefault(t => t.username == username);
                db.users.Remove(userToDelete);
                db.SaveChanges();
            }
        }
    }
}
