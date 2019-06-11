using ShopAccessApp.BackEnd.Enums;
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

namespace ShopAccessApp.UserControlers
{
    /// <summary>
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : UserControl
    {
        public LoginForm()
        {
            InitializeComponent();

            
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    MainWindow parentWindow = (window as MainWindow);
                    if (!String.IsNullOrEmpty(LoginTextBox.Text) && !String.IsNullOrEmpty(PasswordTextBox.Password))
                    {
                        UserType accountType = UserManagement.LoginAs(LoginTextBox.Text, PasswordTextBox.Password);

                        parentWindow.LogIn(accountType);
                    }
                    else
                    {
                        MessageBox.Show("Aby się zalogować należy podać login i hasło");
                    }
                }
            }
            
        }
    }
}
