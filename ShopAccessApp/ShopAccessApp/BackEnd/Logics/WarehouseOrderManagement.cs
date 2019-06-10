using ShopAccessApp.BackEnd.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAccessApp.BackEnd.Logics
{
    public class WarehouseOrderManagement
    {
        public warehouse_orders LocalOrder { get; set; }

        public WarehouseOrderManagement(warehouse_orders localOrder)
        {
            LocalOrder = new warehouse_orders();
            LocalOrder.status = (int)WarehouseOrderStatus.ReadyToOrder;
        }

        #region Motherboards
        public void AddMotherboardToOrder(motherboards temporaryMotherboard, int amount)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                var DBmotherboard = db.motherboards.SingleOrDefault(t => t.id == temporaryMotherboard.id);
                LocalOrder.motherboards = DBmotherboard;
                LocalOrder.motherboard_amount = amount;
            }
        }

        public void RemoveMotherboardFromOrder()
        {
            LocalOrder.motherboards = null;
            LocalOrder.motherboard_amount = 0;
        }
        #endregion

        #region Processors
        public void AddProcessorToOrder(processors temporaryProcessor, int amount)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                var DBprocessor = db.processors.SingleOrDefault(t => t.id == temporaryProcessor.id);
                LocalOrder.processors = DBprocessor;
                LocalOrder.processor_amount = amount;
            }
        }

        public void RemoveProcessorFromOrder()
        {
            LocalOrder.processors = null;
            LocalOrder.processor_amount = 0;
        }
        #endregion

        #region RamMemories
        public void AddRamMemoryToOrder(ram_memories temporaryRamMemory, int amount)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                var DBRamMemory = db.ram_memories.SingleOrDefault(t => t.id == temporaryRamMemory.id);
                LocalOrder.ram_memories = DBRamMemory;
                LocalOrder.ram_memory_amount = amount;
            }
        }

        public void RemoveRamMemoryFromOrder()
        {
            LocalOrder.ram_memories = null;
            LocalOrder.ram_memory_amount = 0;
        }
        #endregion

        #region GraphicCards
        public void AddGraphicsCardToOrder(graphics_cards temporaryGraphicsCard, int amount)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                var DBGraphicsCard = db.graphics_cards.SingleOrDefault(t => t.id == temporaryGraphicsCard.id);
                LocalOrder.graphics_cards = DBGraphicsCard;
                LocalOrder.graphics_card_amount = amount;
            }
        }

        public void RemoveGraphicsCardFromOrder()
        {
            LocalOrder.graphics_cards = null;
            LocalOrder.graphics_card_amount = 0;
        }
        #endregion

        #region Cases
        public void AddCaseToOrder(cases temporaryCase, int amount)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                var DBCase = db.cases.SingleOrDefault(t => t.id == temporaryCase.id);
                LocalOrder.cases = DBCase;
                LocalOrder.case_amount = amount;
            }
        }

        public void RemoveCaseFromOrder()
        {
            LocalOrder.cases = null;
            LocalOrder.case_amount = 0;
        }
        #endregion

        #region Finalization
        public void FinalizeOrder(wholesalers localWholesaler, string additionalInformation)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                var DBWholesaler = db.wholesalers.SingleOrDefault(t => t.id == localWholesaler.id);

                if (LocalOrder.cases != null)
                {
                    LocalOrder.id_case = LocalOrder.cases.id;
                    db.cases.SingleOrDefault(t => t.id == LocalOrder.id_case).warehouse_orders.Add(LocalOrder);
                }
                if (LocalOrder.graphics_cards != null)
                {
                    LocalOrder.id_graphics_card = LocalOrder.graphics_cards.id;
                    db.graphics_cards.SingleOrDefault(t => t.id == LocalOrder.id_graphics_card).warehouse_orders.Add(LocalOrder);
                }
                if (LocalOrder.motherboards != null)
                {
                    LocalOrder.id_motherboard = LocalOrder.motherboards.id;
                    db.motherboards.SingleOrDefault(t => t.id == LocalOrder.id_motherboard).warehouse_orders.Add(LocalOrder);
                }
                if (LocalOrder.processors != null)
                {
                    LocalOrder.id_processor = LocalOrder.processors.id;
                    db.processors.SingleOrDefault(t => t.id == LocalOrder.id_processor).warehouse_orders.Add(LocalOrder);
                }
                if (LocalOrder.ram_memories != null)
                {
                    LocalOrder.id_ram_memory = LocalOrder.ram_memories.id;
                    db.ram_memories.SingleOrDefault(t => t.id == LocalOrder.id_ram_memory).warehouse_orders.Add(LocalOrder);
                }
                LocalOrder.id_wholesaler = DBWholesaler.id;
                LocalOrder.wholesalers = DBWholesaler;
                LocalOrder.additional_information = additionalInformation;
                LocalOrder.status = (int)WarehouseOrderStatus.Ordered;
                LocalOrder.order_date = DateTime.Now;
                db.warehouse_orders.Add(LocalOrder);
                db.SaveChanges();
            }
        }
        #endregion
    }
}
