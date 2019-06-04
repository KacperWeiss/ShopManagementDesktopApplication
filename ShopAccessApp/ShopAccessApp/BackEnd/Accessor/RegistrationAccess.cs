using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAccessApp.BackEnd
{
    static public class RegistrationAccess
    {
        static public List<Registration> GetAll()
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.Registration.ToList<Registration>();
            }
        }

        static public Registration GetByActivationCode(string activationCode)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.Registration.SingleOrDefault(t => t.activation_code == activationCode);
            }
        }

        static public void CreateNew(Registration newRegistration)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                db.Registration.Add(newRegistration);
                db.SaveChanges();
            }
        }

        static public void DeleteByActivationCode(string activationCode)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                Registration registration = db.Registration.SingleOrDefault(x => x.activation_code == activationCode);

                var entry = db.Entry(registration);
                if (entry.State == System.Data.Entity.EntityState.Detached)
                    db.Registration.Attach(registration);
                db.Registration.Remove(registration);
                db.SaveChanges();
            }
        }
    }
}
