using ShopAccessApp.BackEnd.Enums;
using ShopAccessApp.UserControlers;
using ShopAccessApp.UserControlers.ProductEntries;
using ShopAccessApp.UserControlers.Tabs;
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
        int menuPointerOffset = 112;
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

        public void LogIn(UserType accountType)
        {
            SellerListViewMenu.Visibility = Visibility.Collapsed;
            StorekeeperListViewMenu.Visibility = Visibility.Collapsed;
            TechnicianListViewMenu.Visibility = Visibility.Collapsed;
            AdministratorListViewMenu.Visibility = Visibility.Collapsed;
            ContentGrid.Children.Clear();

            switch (accountType)
            {
                case UserType.Seller:
                    SellerListViewMenu.Visibility = Visibility.Visible;
                    SellerListViewMenu.SelectedValue = 0;
                    break;
                case UserType.WarehouseKeeper:
                    StorekeeperListViewMenu.Visibility = Visibility.Visible;
                    StorekeeperListViewMenu.SelectedValue = 0;
                    break;
                case UserType.Technician:
                    TechnicianListViewMenu.Visibility = Visibility.Visible;
                    TechnicianListViewMenu.SelectedValue = 0;
                    break;
                case UserType.Admin:
                    AdministratorListViewMenu.Visibility = Visibility.Visible;
                    AdministratorListViewMenu.SelectedValue = 0;
                    break;
                default:
                    break;
            }

            MiddleScreenPopupGrid.Children.Clear();
            MenuGrid.Visibility = Visibility.Visible;
            ContentGrid.Visibility = Visibility.Visible;
            menuPointer.Margin = new Thickness(0, menuPointerOffset, 0, 0);
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

        private void SellerListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = SellerListViewMenu.SelectedIndex;
            transitioningContentSlide.OnApplyTemplate();
            menuPointer.Margin = new Thickness(0, menuPointerOffset + (60 * index), 0, 0);

            switch (index)
            {
                case 0:
                    var productTab = new ProductTab();
                    ContentGrid.Children.Clear();
                    ContentGrid.Children.Add(productTab);
                    break;
                case 1:
                    var complaintTab = new ComplaintTab();
                    ContentGrid.Children.Clear();
                    ContentGrid.Children.Add(complaintTab);
                    break;
                case 2:
                    ContentGrid.Children.Clear();
                    ShowLoginForm();
                    break;
                default:
                    break;
            }
        }

        private void StorekeeperListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = StorekeeperListViewMenu.SelectedIndex;
            transitioningContentSlide.OnApplyTemplate();
            menuPointer.Margin = new Thickness(0, menuPointerOffset + (60 * index), 0, 0);

            switch (index)
            {
                case 0:
                    var productStorageTab = new ProductStorageTab();
                    ContentGrid.Children.Clear();
                    ContentGrid.Children.Add(productStorageTab);
                    break;
                case 1:
                    ContentGrid.Children.Clear();
                    break;
                case 2:
                    ContentGrid.Children.Clear();
                    ShowLoginForm();
                    break;
                default:
                    break;
            }
        }

        private void TechnicianListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = TechnicianListViewMenu.SelectedIndex;
            transitioningContentSlide.OnApplyTemplate();
            menuPointer.Margin = new Thickness(0, menuPointerOffset + (60 * index), 0, 0);

            switch (index)
            {
                case 0:
                    ContentGrid.Children.Clear();
                    break;
                case 1:
                    ContentGrid.Children.Clear();
                    break;
                case 2:
                    ContentGrid.Children.Clear();
                    ShowLoginForm();
                    break;
                default:
                    break;
            }
        }

        private void AdministratorListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = AdministratorListViewMenu.SelectedIndex;
            transitioningContentSlide.OnApplyTemplate();
            menuPointer.Margin = new Thickness(0, menuPointerOffset + (60 * index), 0, 0);

            switch (index)
            {
                case 0:
                    var userManagementTab = new UsersManagementTab();
                    ContentGrid.Children.Clear();
                    ContentGrid.Children.Add(userManagementTab);
                    break;
                case 1:
                    var administratorOrderTab = new AdministratorOrderTab();
                    ContentGrid.Children.Clear();
                    ContentGrid.Children.Add(administratorOrderTab);
                    break;
                case 2:
                    var newProductEntry = new NewProductEntry();
                    ContentGrid.Children.Clear();
                    ContentGrid.Children.Add(newProductEntry);
                    break;
                case 3:
                    ContentGrid.Children.Clear();
                    ShowLoginForm();
                    break;
                default:
                    break;
            }
        }
    }
}
