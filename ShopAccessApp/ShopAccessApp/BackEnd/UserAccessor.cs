using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAccessApp.BackEnd
{
    public class UserAccessor
    {
        public List<graphics_cards> GetAllUsers()
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.graphic_cards.ToList();
            }
        }

        public graphics_cards GetUserByUsername(string username)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.graphic_cards.SingleOrDefault(t => t.username == username);
            }
        }

        public void CreateNewUser(graphics_cards newUser)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                db.graphic_cards.Add(newUser);
                db.SaveChanges();
            }
        }

        public void DeleteUserByUsername(string username)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                var userToDelete = db.graphic_cards.SingleOrDefault(t => t.username == username);
                db.graphic_cards.Remove(userToDelete);
                db.SaveChanges();
            }
        }
    }
}
