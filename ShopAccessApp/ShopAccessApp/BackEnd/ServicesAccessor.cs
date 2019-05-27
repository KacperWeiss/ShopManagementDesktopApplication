using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAccessApp.BackEnd
{
    public class ServicesAccessor
    {
        public List<services> GetAllServices()
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.services.ToList<services>();
            }
        }

        public services GetServiceByID(int id)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.services.SingleOrDefault(t => t.id == id);
            }
        }

        public void CreateNewService(services newService)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                db.services.Add(newService);
                db.SaveChanges();
            }
        }

        public void DeleteServiceByID(int id)
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
