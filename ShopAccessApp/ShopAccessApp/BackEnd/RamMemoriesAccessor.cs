using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAccessApp.BackEnd
{
    static public class RamMemoriesAccessor
    {
        static public List<ram_memories> GetAllRamMemories()
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.ram_memories.ToList<ram_memories>();
            }
        }

        static public ram_memories GetRamMemoriesByType(string type)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.ram_memories.SingleOrDefault(t => t.type == type);
            }
        }

        static public ram_memories GetRamMemoriesByModel(string model)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.ram_memories.SingleOrDefault(t => t.model == model);
            }
        }

        static public void CreateRamMemories(ram_memories ram)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                db.ram_memories.Add(ram);
                db.SaveChanges();
            }
        }

        static public void DeleteRamMemoriesByModel(string model)
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
