using ShopAccessApp.BackEnd.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAccessApp.BackEnd.Logics
{
    static public class ReclamationManagement
    {
        static public client_order_sets LocalOrder { get; set; } = new client_order_sets();
        
        static public void AddMotherboardToReclamation(motherboards temporaryMotherboard, int amount)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                LocalOrder.motherboards = db.motherboards.SingleOrDefault(t => t.id == temporaryMotherboard.id);
                LocalOrder.id_motherboard = LocalOrder.motherboards.id;
                LocalOrder.motherboard_amount = amount;
            }
        }

        static public void AddProcessorToReclamation(processors temporaryProcessor, int amount)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                LocalOrder.processors = db.processors.SingleOrDefault(t => t.id == temporaryProcessor.id);
                LocalOrder.id_processor = LocalOrder.processors.id;
                LocalOrder.processor_amount = amount;
            }
        }

        static public void AddRamMemoriesToReclamation(ram_memories temporaryRamMemory, int amount)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                LocalOrder.ram_memories = db.ram_memories.SingleOrDefault(t => t.id == temporaryRamMemory.id);
                LocalOrder.id_ram_memory = LocalOrder.ram_memories.id;
                LocalOrder.ram_memory_amount = amount;
            }
        }

        static public void AddGraphicCardsToReclamation(graphics_cards temporaryGraphicCard, int amount)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                LocalOrder.graphics_cards = db.graphics_cards.SingleOrDefault(t => t.id == temporaryGraphicCard.id);
                LocalOrder.id_graphics_card = LocalOrder.graphics_cards.id;
                LocalOrder.graphics_card_amount = amount;
            }
        }

        static public void AddCasesToReclamation(cases temporaryCase, int amount)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                LocalOrder.cases = db.cases.SingleOrDefault(t => t.id == temporaryCase.id);
                LocalOrder.id_case = LocalOrder.cases.id;
                LocalOrder.case_amount = amount;
            }
        }

        static public void AddWholeOrderToReclamation(client_order_sets tempOrder)
        {
            if (tempOrder.cases != null)
            {
                AddCasesToReclamation(tempOrder.cases, (int)tempOrder.case_amount);
            }
            if (tempOrder.graphics_cards != null)
            {
                AddGraphicCardsToReclamation(tempOrder.graphics_cards, (int)tempOrder.graphics_card_amount);
            }
            if (tempOrder.motherboards != null)
            {
                AddMotherboardToReclamation(tempOrder.motherboards, (int)tempOrder.motherboard_amount);
            }
            if (tempOrder.processors != null)
            {
                AddProcessorToReclamation(tempOrder.processors, (int)tempOrder.processor_amount);
            }
            if (tempOrder.ram_memories != null)
            {
                AddRamMemoriesToReclamation(tempOrder.ram_memories, (int)tempOrder.ram_memory_amount);
            }
        }

        static public void FinalizeReclamation(clients client)
        {
            client.client_order_sets.Add(LocalOrder);
            LocalOrder.clients = client;
            LocalOrder.id_client = client.id;
            LocalOrder.status = (short)ClientOrderStatus.Reclamated;
            LocalOrder.order_price = 0;

            using (var db = new StudiaProjektBazyDanychEntities())
            {
                LocalOrder.services = db.services.SingleOrDefault(t => t.service == "Reklamacja");
                db.client_order_sets.Add(LocalOrder);
                db.SaveChanges();
            }
        }
    }
}
