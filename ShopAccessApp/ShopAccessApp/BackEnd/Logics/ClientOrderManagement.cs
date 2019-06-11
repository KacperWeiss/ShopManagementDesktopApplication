using ShopAccessApp.BackEnd.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAccessApp.BackEnd.Logics
{
    static public class ClientOrderManagement
    {
        static public client_order_sets LocalOrder { get; set; } = new client_order_sets();

        #region Motherboards
        static public void AddMotherboardToOrder(motherboards temporaryMotherboard, int amount)
        {
            LocalOrder.motherboards = new motherboards()
            {
                model = temporaryMotherboard.model,
                cpu_socket = temporaryMotherboard.cpu_socket,
                ram_memory_type = temporaryMotherboard.ram_memory_type,
                ram_memory_slots = temporaryMotherboard.ram_memory_slots,
                price = temporaryMotherboard.price,
                amount = amount,
                image_source = temporaryMotherboard.image_source,
                description = temporaryMotherboard.description
            };
        }

        static public void RemoveMotherboardFromOrder()
        {
            LocalOrder.motherboards = null;
        }
        #endregion

        #region Processors
        static public void AddProcessorToOrder(processors temporaryProcessor, int amount)
        {
            LocalOrder.processors = new processors()
            {
                model = temporaryProcessor.model,
                brand = "Brand",
                socket = temporaryProcessor.socket,
                price = temporaryProcessor.price,
                amount = amount,
                image_source = temporaryProcessor.image_source,
                description = temporaryProcessor.description
            };
        }

        static public void RemoveProcessorFromOrder()
        {
            LocalOrder.processors = null;
        }
        #endregion

        #region RamMemories
        static public void AddRamMemoryToOrder(ram_memories temporaryRamMemory, int amount)
        {
            LocalOrder.ram_memories = new ram_memories()
            {
                model = temporaryRamMemory.model,
                type = temporaryRamMemory.type,
                capacity_gb = temporaryRamMemory.capacity_gb,
                price = temporaryRamMemory.price,
                amount = amount,
                image_source = temporaryRamMemory.image_source,
                description = temporaryRamMemory.description
            };
        }

        static public void RemoveRamMemoryFromOrder()
        {
            LocalOrder.ram_memories = null;
        }
        #endregion

        #region GraphicsCards
        static public void AddGraphicsCardToOrder(graphics_cards temporaryGraphicsCard, int amount)
        {
            LocalOrder.graphics_cards = new graphics_cards()
            {
                model = temporaryGraphicsCard.model,
                brand = "Brand",
                price = temporaryGraphicsCard.price,
                amount = amount,
                image_source = temporaryGraphicsCard.image_source,
                description = temporaryGraphicsCard.description
            };
        }

        static public void RemoveGraphicsCardFromOrder()
        {
            LocalOrder.graphics_cards = null;
        }
        #endregion

        #region Cases
        static public void AddCaseToOrder(cases temporaryCase, int amount)
        {
            LocalOrder.cases = new cases()
            {
                model = temporaryCase.model,
                price = temporaryCase.price,
                amount = amount,
                image_source = temporaryCase.image_source,
                description = temporaryCase.description
            };
        }

        static public void RemoveCaseFromOrder()
        {
            LocalOrder.graphics_cards = null;
        }
        #endregion

        #region Services
        static public void AddServiceToOrder(services temporaryService)
        {
            LocalOrder.services = new services()
            {
                service = temporaryService.service,
                price = temporaryService.price
            };
        }

        static public void RemoveServiceFromOrder()
        {
            LocalOrder.graphics_cards = null;
        }
        #endregion

        #region Finalization
        static public void FinalizeOrder(clients temporaryClient, string additionalInformation)
        {
            clients OrderClient = new clients()
            {
                name = temporaryClient.name,
                surname = temporaryClient.surname,
                city = temporaryClient.city,
                street = temporaryClient.street,
                building_number = temporaryClient.building_number,
                apartment_number = temporaryClient.apartment_number,
                post_code = temporaryClient.post_code,
                phone_number = temporaryClient.phone_number,
                email = temporaryClient.email
            };

            OrderClient.client_order_sets.Add(LocalOrder);

            using (var db = new StudiaProjektBazyDanychEntities())
            {
                db.clients.Add(OrderClient);

                if (LocalOrder.cases != null)
                {
                    LocalOrder.cases.client_order_sets.Add(LocalOrder);
                    LocalOrder.case_amount = LocalOrder.cases.amount;

                    var DBCase = db.cases
                                        .SingleOrDefault(t => t.model == LocalOrder.cases.model && t.client_order_sets.Count == 0);
                    DBCase.amount -= LocalOrder.case_amount;

                    db.cases.Add(LocalOrder.cases);
                }
                if (LocalOrder.graphics_cards != null)
                {
                    LocalOrder.graphics_cards.client_order_sets.Add(LocalOrder);
                    LocalOrder.graphics_card_amount = LocalOrder.graphics_cards.amount;

                    var DBGraphicsCard = db.graphics_cards
                                        .SingleOrDefault(t => t.model == LocalOrder.graphics_cards.model && t.client_order_sets.Count == 0);
                    DBGraphicsCard.amount -= LocalOrder.graphics_card_amount;

                    db.graphics_cards.Add(LocalOrder.graphics_cards);
                }
                if (LocalOrder.processors != null)
                {
                    LocalOrder.processors.client_order_sets.Add(LocalOrder);
                    LocalOrder.processor_amount = LocalOrder.processors.amount;

                    var DBprocessor = db.processors
                                    .SingleOrDefault(t => t.model == LocalOrder.processors.model && t.client_order_sets.Count == 0);
                    DBprocessor.amount -= LocalOrder.processor_amount;

                    db.processors.Add(LocalOrder.processors);
                }
                if (LocalOrder.ram_memories != null)
                {
                    LocalOrder.ram_memories.client_order_sets.Add(LocalOrder);
                    LocalOrder.ram_memory_amount = LocalOrder.ram_memories.amount;

                    var DBRamMemory = db.ram_memories
                                    .SingleOrDefault(t => t.model == LocalOrder.ram_memories.model && t.client_order_sets.Count == 0);
                    DBRamMemory.amount -= LocalOrder.ram_memory_amount;

                    db.ram_memories.Add(LocalOrder.ram_memories);
                }
                if (LocalOrder.motherboards != null)
                {
                    LocalOrder.motherboards.client_order_sets.Add(LocalOrder);
                    LocalOrder.motherboard_amount = LocalOrder.motherboards.amount;

                    var DBmotherboard = db.motherboards
                                         .SingleOrDefault(t => t.model == LocalOrder.motherboards.model && t.client_order_sets.Count == 0);
                    DBmotherboard.amount -= LocalOrder.motherboard_amount;

                    db.motherboards.Add(LocalOrder.motherboards);
                }
                if (LocalOrder.services != null)
                {
                    LocalOrder.services.client_order_sets.Add(LocalOrder);
                    db.services.Add(LocalOrder.services);
                }
                LocalOrder.additional_information = additionalInformation;
                LocalOrder.status = (short)ClientOrderStatus.Ordered;
                LocalOrder.order_price = CalculatePrice();
                LocalOrder.order_date = DateTime.Now;

                db.client_order_sets.Add(LocalOrder);
                db.SaveChanges();
                LocalOrder.id_client = LocalOrder.clients.id;
                db.SaveChanges();
                ResetOrder();
            }
        }

        static public void ResetOrder()
        {
            LocalOrder = new client_order_sets() { status = (short)WarehouseOrderStatus.ReadyToOrder };
        }

        static public decimal CalculatePrice()
        {
            decimal totalPrice = 0m;
            if (LocalOrder.cases != null)
            {
                totalPrice += (decimal)LocalOrder.cases.price * (decimal)LocalOrder.cases.amount;
            }
            if (LocalOrder.graphics_cards != null)
            {
                totalPrice += (decimal)LocalOrder.graphics_cards.price * (decimal)LocalOrder.graphics_cards.amount;
            }
            if (LocalOrder.processors != null)
            {
                totalPrice += (decimal)LocalOrder.processors.price * (decimal)LocalOrder.processors.amount;
            }
            if (LocalOrder.ram_memories != null)
            {
                totalPrice += (decimal)LocalOrder.ram_memories.price * (decimal)LocalOrder.ram_memories.amount;
            }
            if (LocalOrder.motherboards != null)
            {
                totalPrice += (decimal)LocalOrder.motherboards.price * (decimal)LocalOrder.motherboards.amount;
            }
            if (LocalOrder.services != null)
            {
                totalPrice += (decimal)LocalOrder.services.price;
            }

            return totalPrice;
        }
        #endregion
    }
}
