using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAccessApp.BackEnd
{
    static public class ServicesAccessor
    {
        static public List<services> GetAllServices()
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.services.ToList<services>();
            }
        }

        static public services GetServiceByID(int id)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.services.SingleOrDefault(t => t.id == id);
            }
        }

        static public void CreateNewService(services newService)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                db.services.Add(newService);
                db.SaveChanges();
            }
        }

        static public void DeleteServiceByID(int id)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                services service = db.services.SingleOrDefault(x => x.id == id);

                var entry = db.Entry(service);
                if (entry.State == System.Data.Entity.EntityState.Detached)
                    db.services.Attach(service);
                db.services.Remove(service);
                db.SaveChanges();
            }

        }
    }
}
