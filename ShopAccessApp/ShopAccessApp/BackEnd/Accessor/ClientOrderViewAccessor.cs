using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAccessApp.BackEnd.Accessor
{
    static public class ClientOrderViewAccessor
    {
        static public List<client_order_set_view> GetAll()
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.client_order_set_view.ToList<client_order_set_view>();
            }
        }

        static public client_order_set_view GetByDateTime(DateTime dateTime)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.client_order_set_view.SingleOrDefault(t => t.order_date == dateTime);
            }
        }
    }
}
