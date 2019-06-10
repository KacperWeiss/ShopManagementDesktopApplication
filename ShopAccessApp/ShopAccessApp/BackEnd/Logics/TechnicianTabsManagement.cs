using ShopAccessApp.BackEnd.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAccessApp.BackEnd.Logics
{
    static public class TechnicianTabsManagement
    {
        static public List<client_order_sets> GetClientOrdersWithService()
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.client_order_sets.Where(t => t.services != null).ToList();
            }
        }

        static public void MarkServiceAsCompletedById(int id)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                var order = db.client_order_sets.SingleOrDefault(t => t.id == id);
                order.status = (short)ClientOrderStatus.ServiceCompleted;
                db.SaveChanges();
            }
        }
    }
}
