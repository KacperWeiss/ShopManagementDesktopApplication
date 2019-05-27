using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAccessApp.BackEnd
{
    public class RegistrationAccess
    {
        public List<Registration> GetAllRegistration()
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.Registration.ToList<Registration>();
            }
        }

        public Registration GetRegistrationByActivationCode(string activationCode)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.Registration.SingleOrDefault(t => t.activation_code == activationCode);
            }
        }

        public void CreateNewRegistration(Registration newRegistration)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                db.Registration.Add(newRegistration);
                db.SaveChanges();
            }
        }

        public void DeleteRegistrationByActivationCode(string activationCode)
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
