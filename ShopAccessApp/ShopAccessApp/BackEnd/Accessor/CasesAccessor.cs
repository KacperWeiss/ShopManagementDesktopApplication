using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAccessApp.BackEnd
{
    static public class CasesAccessor
    {
        static public List<cases> GetAll()
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.cases
                         .Where(t => t.client_order_sets.Count == 0)
                         .ToList<cases>();
            }
        }

        static public cases GetByModel(string caseModel)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.cases
                         .Where(t => t.client_order_sets.Count == 0)
                         .SingleOrDefault(t => t.model.ToString() == caseModel);
            }
        }

        static public void CreateNew(cases newCase)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                db.cases.Add(newCase);
                db.SaveChanges();
            }
        }

        static public void DeleteByModel(string caseModelName)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                cases casesModel = db.cases.Where(t => t.client_order_sets.Count == 0).SingleOrDefault(x => x.model == caseModelName);

                var entry = db.Entry(casesModel);
                if (entry.State == System.Data.Entity.EntityState.Detached)
                    db.cases.Attach(casesModel);
                db.cases.Remove(casesModel);
                db.SaveChanges();
            }
        }
    }
}
