using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAccessApp.BackEnd.Accessor
{
    public class WarehouseOrderForUI
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }

        public int WholesellerId { get; set; }
        public string WholesellerCompany { get; set; }

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

    static public class WarehouseOrderForUIAccessor
    {
        static public List<WarehouseOrderForUI> GetAll()
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                return db.warehouse_orders.Select(t => new WarehouseOrderForUI()
                {
                    OrderId = t.id,
                    OrderDate = (DateTime)t.order_date,
                    WholesellerId = t.wholesalers.id,
                    WholesellerCompany = t.wholesalers.company,
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
