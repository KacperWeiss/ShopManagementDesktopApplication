﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAccessApp.BackEnd
{
    public class UserAccessor
    {
        public List<users> GetAll()
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.users.ToList();
            }
        }

        public users GetByUsername(string username)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.users.SingleOrDefault(t => t.username == username);
            }
        }

        public void CreateNew(users newUser)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                db.users.Add(newUser);
                db.SaveChanges();
            }
        }

        public void DeleteByUsername(string username)
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
