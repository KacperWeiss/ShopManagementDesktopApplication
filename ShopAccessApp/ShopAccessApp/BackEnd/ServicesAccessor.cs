using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAccessApp.BackEnd
{
    static public class ServicesAccessor
    {
        static public List<services> GetAll()
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.services.ToList<services>();
            }
        }

        static public services GetByID(int id)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.services.SingleOrDefault(t => t.id == id);
            }
        }

        static public void CreateNew(services newService)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                db.services.Add(newService);
                db.SaveChanges();
            }
        }

        static public void DeleteByID(int id)
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
