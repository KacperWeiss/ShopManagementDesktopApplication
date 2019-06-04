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

namespace ShopAccessApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool menuExtended = true;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = listViewMenu.SelectedIndex;
            transitioningContentSlide.OnApplyTemplate();
            //transitioningMenuSlide.tran
            menuPointer.Margin = new Thickness(0, 100 + (60 * index), 0, 0);
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            if (menuExtended)
            {
                menuGrid.Width = 60;
                menuExtended = false;
            }
            else
            {
                menuGrid.Width = 250;
                menuExtended = true;
            }
        }
    }
}
