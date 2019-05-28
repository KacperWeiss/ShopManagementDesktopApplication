using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAccessApp.BackEnd
{
    static public class WholesalersAccessor
    {
        static public List<wholesalers> GetAllWholesalers()
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.wholesalers.ToList<wholesalers>();
            }
        }

        static public wholesalers GetWholesalersByName(string companyName)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.wholesalers.SingleOrDefault(t => t.company == companyName);
            }
        }

        static public void CreateWholesaler(wholesalers wholesaler)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                db.wholesalers.Add(wholesaler);
                db.SaveChanges();
            }
        }

        static public void DeleteWholesalerByName(string companyName)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                wholesalers wholesaler = db.wholesalers.SingleOrDefault(x => x.company == companyName);

                var entry = db.Entry(wholesaler);
                if (entry.State == System.Data.Entity.EntityState.Detached)
                    db.wholesalers.Attach(wholesaler);
                db.wholesalers.Remove(wholesaler);
                db.SaveChanges();
            }
        }
    }
}
