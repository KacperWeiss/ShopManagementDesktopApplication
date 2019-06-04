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
    /// Interaction logic for ProductTab.xaml
    /// </summary>
    public partial class ProductTab : UserControl
    {
        Button previousButton;
        public ProductTab()
        {
            InitializeComponent();
        }

        private void ButtonTab_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tab_Click(object sender, RoutedEventArgs e)
        {
            var currentButton = (Button)e.Source;
            int index = int.Parse(currentButton.Uid);
            TabPointer.Margin = new Thickness(10 + (index * 170),0,0,0);
            currentButton.Background = Brushes.White;

            if (previousButton != null && previousButton != currentButton)
            {
                previousButton.Background = null;
            }
            previousButton = (Button)e.Source;

            switch (index)
            {
                case 0:
                    break;

                case 1:
                    break;

                case 2:
                    break;

                case 3:
                    break;

                case 4:
                    break;

                case 5:
                    break;

                case 6:
                    break;

                default:
                    break;
            }
        }
    }
}
