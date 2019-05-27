using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAccessApp.BackEnd
{
    public class MotherBoardsAcessor
    {
        public List<motherboards> GetAll()
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.motherboards.ToList();
            }
        }

        public motherboards GetByModel(string modelName)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.motherboards.SingleOrDefault(t => t.model == modelName);
            }
        }

        public void CreateNew(motherboards newGraphicCard)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                db.motherboards.Add(newGraphicCard);
                db.SaveChanges();
            }
        }

        public void DeleteByModel(string modelName)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                var userToDelete = db.motherboards.SingleOrDefault(t => t.model == modelName);
                db.motherboards.Remove(userToDelete);
                db.SaveChanges();
            }
        }
    }
}
