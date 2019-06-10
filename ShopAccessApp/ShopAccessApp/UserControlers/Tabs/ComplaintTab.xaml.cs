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
    /// Interaction logic for ComplaintTab.xaml
    /// </summary>
    public partial class ComplaintTab : UserControl, INotifyPropertyChanged
    {
        private List<client_order_sets> clientOrderSetsList = ClientOrdersAccessor.GetAll();
        public List<client_order_sets> ClientOrderSetsList
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
        public ComplaintTab()
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
            testingTextBlock.Text = "Complaint tab:  " + clientOrderSetsList.FirstOrDefault().motherboards.model;
        }
    }
}
