using ShopAccessApp.BackEnd;
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

namespace ShopAccessApp.UserControlers.Tabs
{
    /// <summary>
    /// Interaction logic for UsersManagementTab.xaml
    /// </summary>
    public partial class UsersManagementTab : UserControl, INotifyPropertyChanged
    {
        private string key = "";
        private BackEnd.Enums.UserType userType;
        private List<users> userList = UserAccessor.GetAll();
        public List<users> UserList
        {
            get
            {
                return userList;
            }
            set
            {
                if (userList != value)
                {
                    userList = value;
                    OnPropertyChanged();
                }
            }
        }

        public UsersManagementTab()
        {
            InitializeComponent();
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void UsersScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta / 2);
            e.Handled = true;
        }

        private void GenerateKeyButton_Click(object sender, RoutedEventArgs e)
        {
            key = RegistrationKeyGeneration.GetRandomKey();
            KeyTextBox.Text = key;
        }

        private void CopyKeyButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(key);
        }

        private void SaveKeyButton_Click(object sender, RoutedEventArgs e)
        {
            var index = AccessLevelChoiceComboBox.SelectedIndex;
            if (index != -1)
            {
                switch (index)
                {
                    case 0:
                        userType = BackEnd.Enums.UserType.Seller;
                        break;
                    case 1:
                        userType = BackEnd.Enums.UserType.WarehouseKeeper; 
                        break;
                    case 2:
                        userType = BackEnd.Enums.UserType.Technician;
                        break;
                    case 3:
                        userType = BackEnd.Enums.UserType.Admin;
                        break;
                    default:
                        break;
                }

                RegistrationKeyGeneration.SaveToDatabase(key, userType);
            }
        }
    }
}
