using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAccessApp.BackEnd
{
    static public class UserAccessor
    {
        static public List<users> GetAll()
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.users.ToList();
            }
        }

        static public users GetById(int id)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.users.SingleOrDefault(t => t.id == id);
            }
        }

        static public users GetByUsername(string username)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.users.SingleOrDefault(t => t.username == username);
            }
        }

        static public void CreateNew(users newUser)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                db.users.Add(newUser);
                db.SaveChanges();
            }
        }

        static public void DeleteByUsername(string username)
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
