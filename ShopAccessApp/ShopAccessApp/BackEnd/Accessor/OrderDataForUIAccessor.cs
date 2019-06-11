using ShopAccessApp.BackEnd.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAccessApp.BackEnd.Accessor
{
    public class OrderDataForUI
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }

        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }

        public int ProcessorId { get; set; }
        public string ProcessorModel { get; set; }

        public int MotherboardId { get; set; }
        public string MotherboardModel { get; set; }

        public int GraphicCardId { get; set; }
        public string GraphicCardModel { get; set; }

        public int RamMemoryId { get; set; }
        public string RamMemoryModel { get; set; }

        public int CaseId { get; set; }
        public string CaseModel { get; set; }

        public short OrderStatus { get; set; }
    }

    static public class OrderDataForUIAccessor
    {
        static public List<OrderDataForUI> GetAll()
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.client_order_sets.Select(t => new OrderDataForUI()
                {
                    OrderId = t.id,
                    OrderDate = (DateTime)t.order_date,
                    ClientId = t.clients.id,
                    ClientName = t.clients.name,
                    ClientSurname = t.clients.surname,
                    ProcessorId = t.processors.id,
                    ProcessorModel = t.processors.model,
                    MotherboardId = t.motherboards.id,
                    MotherboardModel = t.motherboards.model,
                    GraphicCardId = t.graphics_cards.id,
                    RamMemoryId = t.ram_memories.id,
                    RamMemoryModel = t.ram_memories.model,
                    CaseId = t.cases.id,
                    CaseModel = t.cases.model,
                    OrderStatus = t.status
                })
                .ToList();
            }
        }
    }
}
