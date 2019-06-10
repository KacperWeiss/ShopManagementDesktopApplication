using ShopAccessApp.BackEnd;
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

namespace ShopAccessApp.UserControlers.ProductEntries
{
    /// <summary>
    /// Interaction logic for NewProductEntry.xaml
    /// </summary>
    public partial class NewProductEntry : UserControl
    {
        public NewProductEntry()
        {
            InitializeComponent();
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddMotherboard()
        {
            
        }

        private void AddProcessor()
        {

        }

        private void AddGraphicsCard()
        {
            graphics_cards graphicsCard = new graphics_cards()
            {
                model = ModelNameTextBox.Text,
                brand = ,
                price = temporaryGraphicsCard.price,
                amount = amount,
                image_source = temporaryGraphicsCard.image_source,
                description = temporaryGraphicsCard.description
            };
        }

        private void AddRamMemory()
        {

        }

        private void AddCase()
        {

        }

        private void ProductTypeSelectionComboBox_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
