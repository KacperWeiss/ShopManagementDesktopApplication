﻿using ShopAccessApp.BackEnd.Accessor;
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
    /// Interaction logic for AdministratorOrderTab.xaml
    /// </summary>
    public partial class AdministratorOrderTab : UserControl
    {
        private List<OrderDataForUI> clientOrderSetsList = OrderDataForUIAccessor.GetAll();
        public List<OrderDataForUI> ClientOrderSetsList
        {
            get
            {
                return clientOrderSetsList;
            }
            set
            {
                if (clientOrderSetsList != value)
                {
                    clientOrderSetsList = value;
                    OnPropertyChanged();
                }
            }
        }
        private List<WarehouseOrderForUI> warehouseOrderSetsList = WarehouseOrderForUIAccessor.GetAll();
        public List<WarehouseOrderForUI> WarehouseOrderSetsList
        {
            get
            {
                return warehouseOrderSetsList;
            }
            set
            {
                if (warehouseOrderSetsList != value)
                {
                    warehouseOrderSetsList = value;
                    OnPropertyChanged();
                }
            }
        }

        public AdministratorOrderTab()
        {
            InitializeComponent();
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ClientOrderSetsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TestingButton_Click(object sender, RoutedEventArgs e)
        {
            //testingTextBlock.Text = "Complaint tab:  " + clientOrderSetsList.FirstOrDefault().motherboards.model;
        }

        private void SubmitComplaintButton_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new StudiaProjektBazyDanychEntities())
            {
                var localOrder = db.client_order_sets.SingleOrDefault(t => t.id == clientOrderSetsList[ClientOrderSetsListView.SelectedIndex].OrderId);
                ReclamationManagement.AddWholeOrderToReclamation(localOrder);
                ReclamationManagement.FinalizeReclamation(localOrder.clients);
            }
        }
    }
}
