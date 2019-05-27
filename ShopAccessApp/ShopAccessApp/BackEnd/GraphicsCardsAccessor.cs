using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAccessApp.BackEnd
{
    public class GraphicsCardsAccessor
    {
        public List<graphics_cards> GetAll()
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.graphics_cards.ToList();
            }
        }

        public graphics_cards GetByModel(string modelName)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.graphics_cards.SingleOrDefault(t => t.model == modelName);
            }
        }

        public List<graphics_cards> GetByBrand(string brandName)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.graphics_cards.Where(t => t.brand == brandName).ToList();
            }
        }

        public void CreateNew(graphics_cards newGraphicCard)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                db.graphics_cards.Add(newGraphicCard);
                db.SaveChanges();
            }
        }

        public void DeleteByModel(string modelName)
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
