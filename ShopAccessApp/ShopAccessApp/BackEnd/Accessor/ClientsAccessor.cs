using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAccessApp.BackEnd
{
    static public class ClientsAccessor
    {
        static public List<clients> GetAll()
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.clients.ToList<clients>();
            }
        }

        static public clients GetByName(string name, string surname)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.clients.SingleOrDefault(t => t.name == name && t.surname == surname);
            }
        }

        static public void CreateNew(clients newClient)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                db.clients.Add(newClient);
                db.SaveChanges();
            }
        }

        static public void DeleteByName(string name, string surname)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                clients client = db.clients.SingleOrDefault(x => x.name == name && x.surname == surname);

                var entry = db.Entry(client);
                if (entry.State == System.Data.Entity.EntityState.Detached)
                    db.clients.Attach(client);
                db.clients.Remove(client);
                db.SaveChanges();
            }
        }
    }
}
