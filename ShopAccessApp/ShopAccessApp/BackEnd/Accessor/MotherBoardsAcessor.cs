using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAccessApp.BackEnd
{
    static public class MotherBoardsAcessor
    {
        static public List<motherboards> GetAll()
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.motherboards.ToList();
            }
        }

        static public motherboards GetByModel(string modelName)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.motherboards.SingleOrDefault(t => t.model == modelName);
            }
        }

        static public void CreateNew(motherboards newGraphicCard)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                db.motherboards.Add(newGraphicCard);
                db.SaveChanges();
            }
        }

        static public void DeleteByModel(string modelName)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                var motherBoardToDelete = db.motherboards.SingleOrDefault(t => t.model == modelName);
                db.motherboards.Remove(motherBoardToDelete);
                db.SaveChanges();
            }
        }
    }
}
