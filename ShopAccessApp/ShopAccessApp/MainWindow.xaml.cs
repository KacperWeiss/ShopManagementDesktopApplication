using ShopAccessApp.UserControlers;
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
        LoginForm loginForm = new LoginForm();

        bool menuExtended = true;
        public MainWindow()
        {
            InitializeComponent();
            ShowLoginForm();
            
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow = this;
        }

        private void ShowLoginForm()
        {
            MenuGrid.Visibility = Visibility.Collapsed;
            ContentGrid.Visibility = Visibility.Collapsed;
            MiddleScreenPopupGrid.Children.Clear();
            MiddleScreenPopupGrid.Children.Add(loginForm);
        }

        public void HideLoginForm()
        {
            MiddleScreenPopupGrid.Children.Clear();
            MenuGrid.Visibility = Visibility.Visible;
            ContentGrid.Visibility = Visibility.Visible;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = listViewMenu.SelectedIndex;
            transitioningContentSlide.OnApplyTemplate();
            menuPointer.Margin = new Thickness(0, 112 + (60 * index), 0, 0);

            switch (index)
            {
                case 0:

                    break;
                case 1:

                    break;
                case 2:

                    break;
                case 3:
                    ShowLoginForm();
                    break;
                default:
                    break;
            }
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            if (menuExtended)
            {
                MenuGrid.Width = 60;
                menuExtended = false;
            }
            else
            {
                MenuGrid.Width = 250;
                menuExtended = true;
            }
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == System.Windows.WindowState.Normal)
            {
                this.WindowState = System.Windows.WindowState.Maximized;
            }
            else
            {
                this.WindowState = System.Windows.WindowState.Normal;
            }
        }

        private void MenuButton_MouseEnter(object sender, MouseEventArgs e)
        {
            MenuButtonColor.Background = new SolidColorBrush(Color.FromArgb(252, 75, 75, 75));
        }

        private void MenuButton_MouseLeave(object sender, MouseEventArgs e)
        {
            MenuButtonColor.Background = null;
        }

        private void MainWindowBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch
            {

            }
        }
    }
}
