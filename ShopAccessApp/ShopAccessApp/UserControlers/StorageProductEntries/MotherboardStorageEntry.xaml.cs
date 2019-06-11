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

namespace ShopAccessApp.UserControlers.StorageProductEntries
{
    /// <summary>
    /// Interaction logic for MotherboardStorageEntry.xaml
    /// </summary>
    public partial class MotherboardStorageEntry : UserControl
    {
        public MotherboardStorageEntry()
        {
            InitializeComponent();
        }

        private void AddToCartButton_Click(object sender, RoutedEventArgs e)
        {
            int amount = AmountPicker.NumValue;
            var motherboard = (motherboards)DataContext;

            WarehouseOrderManagement.AddMotherboardToOrder(motherboard, amount);
        }

        private int incoming = 0;
        public int Incoming
        {
            get
            {
                return incoming;
            }
            set
            {
                if (incoming != value)
                {
                    incoming = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void StorageOrderCountTextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            var id = Convert.ToInt32(IDHolderHack.Text);


            using (var db = new StudiaProjektBazyDanychEntities())
            {
                var total = db.warehouse_orders.Where(t => t.motherboards.id == id).ToList();
                foreach (var item in total)
                {
                    Incoming += (int)item.motherboard_amount;
                }
            }
            StorageOrderCountTextBlock.Text = Incoming.ToString();

        }
    }
}
