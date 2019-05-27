using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAccessApp.BackEnd
{
    public class ProcessorsAccessor
    {
        public List<processors> GetAll()
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.processors.ToList();
            }
        }

        public processors GetByModel(string modelName)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.processors.SingleOrDefault(t => t.model == modelName);
            }
        }

        public void CreateNew(processors newProcessor)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                db.processors.Add(newProcessor);
                db.SaveChanges();
            }
        }

        public void DeleteByModel(string modelName)
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
