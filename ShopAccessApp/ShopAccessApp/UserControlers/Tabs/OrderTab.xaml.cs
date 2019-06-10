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
    /// Interaction logic for OrderTab.xaml
    /// </summary>
    public partial class OrderTab : UserControl
    {
        public OrderTab()
        {
            InitializeComponent();
        }

        private void OrderAcceptButton_Click(object sender, RoutedEventArgs e)
        {
            string additionalInformation = AdditionalInformationTextBox.Text;
            clients OrderClient = new clients()
            {
                name = NameTextBox.Text,
                surname = SurnameTextBox.Text,
                city = CityTextBox.Text,
                street = StreetTextBox.Text,
                building_number = BuildingNumberTextBox.Text,
                apartment_number = ApartmentNumberTextBox.Text,
                post_code = PostcodeTextBox.Text,
                phone_number = PhoneNumberTextBox.Text,
                email = EmailTextBox.Text
            };

            ClientOrderManagement.FinalizeOrder(OrderClient, additionalInformation);
        }

        private void PriceSummaryTextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            PriceSummaryTextBlock.Text = ClientOrderManagement.CalculatePrice().ToString();
        }
    }
}
