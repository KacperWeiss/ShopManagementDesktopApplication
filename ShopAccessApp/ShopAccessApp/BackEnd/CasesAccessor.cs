﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAccessApp.BackEnd
{
    static public class CasesAccessor
    {
        static public List<cases> GetAllCases()
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.cases.ToList<cases>();
            }
        }

        static public cases GetCasesByModel(string caseModel)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.cases.SingleOrDefault(t => t.model.ToString() == caseModel);
            }
        }

        static public void CreateNewCase(cases newCase)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                db.cases.Add(newCase);
                db.SaveChanges();
            }
        }

        static public void DeleteCasesByModel(string caseModelName)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                cases casesModel = db.cases.SingleOrDefault(x => x.model == caseModelName);

                var entry = db.Entry(casesModel);
                if (entry.State == System.Data.Entity.EntityState.Detached)
                    db.cases.Attach(casesModel);
                db.cases.Remove(casesModel);
                db.SaveChanges();
            }
        }
    }
}