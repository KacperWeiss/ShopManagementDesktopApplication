using ShopAccessApp.BackEnd.Logics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShopAccessApp.UserControlers.Tabs
{
    /// <summary>
    /// Interaction logic for WarehouseOrderTab.xaml
    /// </summary>
    public partial class WarehouseOrderTab : UserControl
    {
        public WarehouseOrderTab()
        {
            InitializeComponent();
        }

        private void OrderAcceptButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void PriceSummaryTextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            //PriceSummaryTextBlock.Text = WarehouseOrderManagement.CalculatePrice().ToString();

            if (WarehouseOrderManagement.LocalOrder.motherboards != null)
            {
                MotherboardNameTextBlock.Text = WarehouseOrderManagement.LocalOrder.motherboards.model;
                MotherboardPriceTextBlock.Text = WarehouseOrderManagement.LocalOrder.motherboards.price.ToString();
                MotherboardCountTextBlock.Text = WarehouseOrderManagement.LocalOrder.motherboards.amount.ToString();
            }
            if (WarehouseOrderManagement.LocalOrder.processors != null)
            {
                ProcessorNameTextBlock.Text = WarehouseOrderManagement.LocalOrder.processors.model;
                ProcessorPriceTextBlock.Text = WarehouseOrderManagement.LocalOrder.processors.price.ToString();
                ProcessorCountTextBlock.Text = WarehouseOrderManagement.LocalOrder.processors.amount.ToString();
            }
            if (WarehouseOrderManagement.LocalOrder.graphics_cards != null)
            {
                GraphicsCardNameTextBlock.Text = WarehouseOrderManagement.LocalOrder.graphics_cards.model;
                GraphicsCardPriceTextBlock.Text = WarehouseOrderManagement.LocalOrder.graphics_cards.price.ToString();
                GraphicsCardCountTextBlock.Text = WarehouseOrderManagement.LocalOrder.graphics_cards.amount.ToString();
            }
            if (WarehouseOrderManagement.LocalOrder.ram_memories != null)
            {
                RamMemoryNameTextBlock.Text = WarehouseOrderManagement.LocalOrder.ram_memories.model;
                RamMemoryPriceTextBlock.Text = WarehouseOrderManagement.LocalOrder.ram_memories.price.ToString();
                RamMemoryCountTextBlock.Text = WarehouseOrderManagement.LocalOrder.ram_memories.amount.ToString();
            }
            if (WarehouseOrderManagement.LocalOrder.cases != null)
            {
                CaseNameTextBlock.Text = WarehouseOrderManagement.LocalOrder.cases.model;
                CasePriceTextBlock.Text = WarehouseOrderManagement.LocalOrder.cases.price.ToString();
                CaseCountTextBlock.Text = WarehouseOrderManagement.LocalOrder.cases.amount.ToString();
            }

            
        }
    }
}
