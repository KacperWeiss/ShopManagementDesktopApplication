﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAccessApp.BackEnd
{
    public class Cases
    {
        List<cases> GetAllCases()
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.cases.ToList<cases>();
            }
        }

        cases GetCasesByModel(string caseModel)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.cases.SingleOrDefault(t => t.model.ToString() == caseModel);
            }
        }

        void DeleteCasesByModel(string caseModelName)
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
