using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAccessApp.BackEnd
{
    static public class GraphicsCardsAccessor
    {
        static public List<graphics_cards> GetAll()
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.graphics_cards.ToList();
            }
        }

        static public graphics_cards GetByModel(string modelName)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.graphics_cards.SingleOrDefault(t => t.model == modelName);
            }
        }

        static public List<graphics_cards> GetByBrand(string brandName)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.graphics_cards.Where(t => t.brand == brandName).ToList();
            }
        }

        static public void CreateNew(graphics_cards newGraphicCard)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                db.graphics_cards.Add(newGraphicCard);
                db.SaveChanges();
            }
        }

        static public void DeleteByModel(string modelName)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                var userToDelete = db.graphics_cards.SingleOrDefault(t => t.model == modelName);
                db.graphics_cards.Remove(userToDelete);
                db.SaveChanges();
            }
        }
    }
}
