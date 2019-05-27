using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAccessApp.BackEnd
{
    public class GraphicsCardsAccessor
    {
        public List<graphics_cards> GetAllGraphicCards()
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.graphic_cards.ToList();
            }
        }

        public graphics_cards GetGraphicCardByModel(string modelName)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.graphic_cards.SingleOrDefault(t => t.model == modelName);
            }
        }

        public List<graphics_cards> GetGraphicCardsByBrand(string brandName)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.graphic_cards.Where(t => t.brand == brandName).ToList();
            }
        }

        public void CreateNewGraphicCard(graphics_cards newGraphicCard)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                db.graphic_cards.Add(newGraphicCard);
                db.SaveChanges();
            }
        }

        public void DeleteGraphicCardByModel(string brandName)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                var userToDelete = db.graphic_cards.SingleOrDefault(t => t.brand == brandName);
                db.graphic_cards.Remove(userToDelete);
                db.SaveChanges();
            }
        }
    }
}
