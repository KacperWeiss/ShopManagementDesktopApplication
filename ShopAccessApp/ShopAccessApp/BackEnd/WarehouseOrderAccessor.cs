using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAccessApp.BackEnd
{
    static public class WarehouseOrderAccessor
    {
        static public List<warehouse_orders> GetAll()
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.warehouse_orders.ToList<warehouse_orders>();
            }
        }

        #region get
        static public warehouse_orders GetByID(int id)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.warehouse_orders.SingleOrDefault(t => t.id == id);
            }
        }

        static public warehouse_orders GetByStatus(short status)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.warehouse_orders.SingleOrDefault(t => t.status == status);
            }
        }
        #endregion

        static public void CreateNew(warehouse_orders order)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                db.warehouse_orders.Add(order);
                db.SaveChanges();
            }
        }

        static public void DeleteByID(int id)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                warehouse_orders order = db.warehouse_orders.SingleOrDefault(x => x.id == id);

                var entry = db.Entry(order);
                if (entry.State == System.Data.Entity.EntityState.Detached)
                    db.warehouse_orders.Attach(order);
                db.warehouse_orders.Remove(order);
                db.SaveChanges();
            }
        }
    }
}
