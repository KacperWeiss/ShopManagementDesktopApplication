using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAccessApp.BackEnd
{
    static public class RamMemoriesAccessor
    {
        static public List<ram_memories> GetAll()
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.ram_memories
                         .Where(t => t.client_order_sets.Count == 0)
                         .ToList<ram_memories>();
            }
        }

        static public ram_memories GetByType(string type)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.ram_memories
                         .Where(t => t.client_order_sets.Count == 0)
                         .SingleOrDefault(t => t.type == type);
            }
        }

        static public ram_memories GetByModel(string model)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.ram_memories
                         .Where(t => t.client_order_sets.Count == 0)
                         .SingleOrDefault(t => t.model == model);
            }
        }

        static public void Create(ram_memories ram)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                db.ram_memories.Add(ram);
                db.SaveChanges();
            }
        }

        static public void DeleteByModel(string model)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                ram_memories ramModel = db.ram_memories.SingleOrDefault(x => x.model == model);

                var entry = db.Entry(ramModel);
                if (entry.State == System.Data.Entity.EntityState.Detached)
                    db.ram_memories.Attach(ramModel);
                db.ram_memories.Remove(ramModel);
                db.SaveChanges();
            }
        }
    }
}
