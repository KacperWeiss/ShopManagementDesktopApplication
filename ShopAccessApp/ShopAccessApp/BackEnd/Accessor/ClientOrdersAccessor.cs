using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAccessApp.BackEnd.Accessor
{
    static public class ClientOrdersAccessor
    {
        static public List<client_order_sets> GetAll()
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.client_order_sets.ToList<client_order_sets>();
            }
        }

        static public client_order_sets GetById(int id)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.client_order_sets.SingleOrDefault(t => t.id == id);
            }
        }

        static public void DeleteById(int id)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                client_order_sets client_order_set = db.client_order_sets.SingleOrDefault(x => x.id == id);

                var entry = db.Entry(client_order_set);
                if (entry.State == System.Data.Entity.EntityState.Detached)
                    db.client_order_sets.Attach(client_order_set);
                db.client_order_sets.Remove(client_order_set);
                db.SaveChanges();
            }
        }
    }
}
