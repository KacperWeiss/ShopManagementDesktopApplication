using ShopAccessApp.BackEnd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            int index = ProductTypeSelectionComboBox.SelectedIndex;
            switch (index)
            {
                case 0:
                    AddMotherboard();
                    break;
                case 1:
                    AddProcessor();
                    break;
                case 2:
                    AddRamMemory();
                    break;
                case 3:
                    AddGraphicsCard();
                    break;
                case 4:
                    AddCase();
                    break;
                default:
                    break;
            }
            ClearTextBoxes();
        }

        private void ClearTextBoxes()
        {
            ModelNameTextBox.Text = "";
            BrandNameTextBox.Text = "";
            ProcessorSocketTypeTextBox.Text = "";
            RamMemoryTypeTextBox.Text = "";
            RamMemoryCapacityTextBox.Text = "";
            RamMemorySlotsTextBox.Text = "";
            PriceTextBox.Text = "";
            LinkToImageTextBox.Text = "";
            DescriptionTextBox.Text = "";
        }

        private void AddMotherboard()
        {
            motherboards motherboard = new motherboards()
            {
                model = ModelNameTextBox.Text,
                cpu_socket = ProcessorSocketTypeTextBox.Text,
                ram_memory_type = RamMemoryTypeTextBox.Text,
                ram_memory_slots = Int32.Parse(RamMemorySlotsTextBox.Text),
                price = Int32.Parse(PriceTextBox.Text),
                amount = 0,
                image_source = LinkToImageTextBox.Text,
                description = DescriptionTextBox.Text
            };

            MotherBoardsAcessor.CreateNew(motherboard);
        }

        private void AddProcessor()
        {
            processors processor = new processors()
            {
                model = ModelNameTextBox.Text,
                socket = ProcessorSocketTypeTextBox.Text,
                price = Int32.Parse(PriceTextBox.Text),
                amount = 0,
                image_source = LinkToImageTextBox.Text,
                description = DescriptionTextBox.Text
            };

            ProcessorsAccessor.CreateNew(processor);
        }

        private void AddGraphicsCard()
        {
            graphics_cards graphicsCard = new graphics_cards()
            {
                model = ModelNameTextBox.Text,
                brand = BrandNameTextBox.Text,
                price = Int32.Parse(PriceTextBox.Text),
                amount = 0,
                image_source = LinkToImageTextBox.Text,
                description = DescriptionTextBox.Text
            };

            GraphicsCardsAccessor.CreateNew(graphicsCard);
        }

        private void AddRamMemory()
        {
            ram_memories ramMemory = new ram_memories()
            {
                model = ModelNameTextBox.Text,
                type = RamMemoryTypeTextBox.Text,
                capacity_gb = Int32.Parse(RamMemoryCapacityTextBox.Text),
                price = Int32.Parse(PriceTextBox.Text),
                amount = 0,
                image_source = LinkToImageTextBox.Text,
                description = DescriptionTextBox.Text
            };

            RamMemoriesAccessor.Create(ramMemory);
        }

        private void AddCase()
        {
            cases caseInstance = new cases()
            {
                model = ModelNameTextBox.Text,
                price = Int32.Parse(PriceTextBox.Text),
                amount = 0,
                image_source = LinkToImageTextBox.Text,
                description = DescriptionTextBox.Text
            };

            CasesAccessor.CreateNew(caseInstance);
        }

        private void ProductTypeSelectionComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            ProductTypeSelectionComboBox.SelectedIndex = 0;
        }

        private void ProductTypeSelectionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ProductTypeSelectionComboBox.SelectedIndex;

            switch (index)
            {
                case 0:
                    BrandField.Visibility = Visibility.Collapsed;
                    ProcessorSocketTypeField.Visibility = Visibility.Visible;
                    RamMemoryTypeField.Visibility = Visibility.Visible;
                    RamMemoryCapacityField.Visibility = Visibility.Collapsed;
                    RamMemorySlotsField.Visibility = Visibility.Visible;
                    break;
                case 1:
                    BrandField.Visibility = Visibility.Visible;
                    ProcessorSocketTypeField.Visibility = Visibility.Visible;
                    RamMemoryTypeField.Visibility = Visibility.Collapsed;
                    RamMemoryCapacityField.Visibility = Visibility.Collapsed;
                    RamMemorySlotsField.Visibility = Visibility.Collapsed;
                    break;
                case 2:
                    BrandField.Visibility = Visibility.Collapsed;
                    ProcessorSocketTypeField.Visibility = Visibility.Collapsed;
                    RamMemoryTypeField.Visibility = Visibility.Visible;
                    RamMemoryCapacityField.Visibility = Visibility.Visible;
                    RamMemorySlotsField.Visibility = Visibility.Collapsed;
                    break;
                case 3:
                    BrandField.Visibility = Visibility.Visible;
                    ProcessorSocketTypeField.Visibility = Visibility.Collapsed;
                    RamMemoryTypeField.Visibility = Visibility.Collapsed;
                    RamMemoryCapacityField.Visibility = Visibility.Collapsed;
                    RamMemorySlotsField.Visibility = Visibility.Collapsed;
                    break;
                case 4:
                    BrandField.Visibility = Visibility.Collapsed;
                    ProcessorSocketTypeField.Visibility = Visibility.Collapsed;
                    RamMemoryTypeField.Visibility = Visibility.Collapsed;
                    RamMemoryCapacityField.Visibility = Visibility.Collapsed;
                    RamMemorySlotsField.Visibility = Visibility.Collapsed;
                    break;
                default:
                    break;
            }
        }

        private void PriceTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void RamMemoryCapacityTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void RamMemorySlotsTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void LinkToImageTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(LinkToImageTextBox.Text))
            {
                try
                {
                    var uri = new Uri(LinkToImageTextBox.Text);
                    var bitmapImage = new BitmapImage(uri);
                    ProductImage.Source = bitmapImage;
                }
                catch
                {
                    
                }
            }
        }
    }
}
