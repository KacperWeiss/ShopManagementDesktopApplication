using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAccessApp.BackEnd
{
    public class ClientsAccessor
    {
        public List<clients> GetAllClients()
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.clients.ToList<clients>();
            }
        }

        public clients GetCasesByName(string name, string surname)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.clients.SingleOrDefault(t => t.name == name && t.surname == surname);
            }
        }

        public void CreateNewClient(clients newClient)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                db.clients.Add(newClient);
                db.SaveChanges();
            }
        }

        public void DeleteCasesByName(string name, string surname)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                clients client = db.clients.SingleOrDefault(x => x.name == name && x.surname == surname);

                var entry = db.Entry(client);
                if (entry.State == System.Data.Entity.EntityState.Detached)
                    db.clients.Attach(client);
                db.clients.Remove(client);
                db.SaveChanges();
            }
        }
    }
}
