using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAccessApp.BackEnd
{
    public class RamMemoriesAccessor
    {
        public List<ram_memories> GetAllRamMemories()
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.ram_memories.ToList<ram_memories>();
            }
        }

        public ram_memories GetRamMemoriesByType(string type)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.ram_memories.SingleOrDefault(t => t.type == type);
            }
        }

        public ram_memories GetRamMemoriesByModel(string model)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.ram_memories.SingleOrDefault(t => t.model == model);
            }
        }

        public void CreateRamMemories(ram_memories ram)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                db.ram_memories.Add(ram);
                db.SaveChanges();
            }
        }

        public void DeleteRamMemoriesByModel(string model)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                ram_memories ramModel = db.warehouse_orders.SingleOrDefault(x => x.model == model);

                var entry = db.Entry(ramModel);
                if (entry.State == System.Data.Entity.EntityState.Detached)
                    db.ram_memories.Attach(ramModel);
                db.ram_memories.Remove(ramModel);
                db.SaveChanges();
            }
        }
    }
}
