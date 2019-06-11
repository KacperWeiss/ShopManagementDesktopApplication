using ShopAccessApp.BackEnd;
using ShopAccessApp.BackEnd.Logics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public partial class WarehouseOrderTab : UserControl, INotifyPropertyChanged
    {
        private List<wholesalers> wholesalerList = WholesalersAccessor.GetAll();
        private int selectedWholesalerID;

        public List<wholesalers> WholesalerList
        {
            get
            {
                return wholesalerList;
            }
            set
            {
                if (wholesalerList != value)
                {
                    wholesalerList = value;
                    OnPropertyChanged();
                }
            }
        }

        public int SelectedWholesalerID
        {
            get
            {
                return selectedWholesalerID;
            }
            set
            {
                if (selectedWholesalerID != value)
                {
                    selectedWholesalerID = value;
                    OnPropertyChanged();
                }
            }
        }

        public WarehouseOrderTab()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void OrderAcceptButton_Click(object sender, RoutedEventArgs e)
        {
            string additionalInformation = AdditionalInformationTextBox.Text;

            var selectedWholesaler = (wholesalers)WholeSalerSelectionComboBox.SelectedItem;
            WarehouseOrderManagement.FinalizeOrder(selectedWholesaler, additionalInformation);
        }

        private void PriceSummaryTextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            PriceSummaryTextBlock.Text = WarehouseOrderManagement.CalculatePrice().ToString();

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

        private void WholeSalerSelectionComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            wholesalerList = WholesalersAccessor.GetAll();
            //var wholesalers = WholesalersAccessor.GetAll();
            //foreach (var item in wholesalers)
            //{
            //    WholeSalerSelectionComboBox.Items.Add(item.company);
            //}
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
