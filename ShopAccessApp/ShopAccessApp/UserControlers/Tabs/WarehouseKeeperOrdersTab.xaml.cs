using ShopAccessApp.BackEnd.Accessor;
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
    /// Interaction logic for WarehouseKeeperOrdersTab.xaml
    /// </summary>
    public partial class WarehouseKeeperOrdersTab : UserControl
    {
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

        public WarehouseKeeperOrdersTab()
        {
            InitializeComponent();
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
