using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAccessApp.BackEnd
{
    static public class ProcessorsAccessor
    {
        static public List<processors> GetAll()
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.processors
                         .Where(t => t.client_order_sets.Count == 0)
                         .ToList();
            }
        }

        static public processors GetByModel(string modelName)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.processors
                         .Where(t => t.client_order_sets.Count == 0)
                         .SingleOrDefault(t => t.model == modelName);
            }
        }

        static public void CreateNew(processors newProcessor)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                db.processors.Add(newProcessor);
                db.SaveChanges();
            }
        }

        static public void DeleteByModel(string modelName)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                var processorToDelete = db.processors.SingleOrDefault(t => t.model == modelName);
                db.processors.Remove(processorToDelete);
                db.SaveChanges();
            }
        }
    }
}
