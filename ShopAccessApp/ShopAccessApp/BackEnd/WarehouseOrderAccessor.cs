using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAccessApp.BackEnd
{
    public class WarehouseOrderAccessor
    {
        public List<warehouse_orders> GetAllWarehouseOrder()
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.warehouse_orders.ToList<warehouse_orders>();
            }
        }

        #region get
        public warehouse_orders GetWholesalersByWholesalerID(int id)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.warehouse_orders.SingleOrDefault(t => t.id == id);
            }
        }

        public warehouse_orders GetWholesalersByStatus(short status)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.warehouse_orders.SingleOrDefault(t => t.status == status);
            }
        }
        #endregion

        public void CreateWarehouseOrder(warehouse_orders order)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                db.warehouse_orders.Add(order);
                db.SaveChanges();
            }
        }

        public void DeleteWholesalerByID(int id)
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
