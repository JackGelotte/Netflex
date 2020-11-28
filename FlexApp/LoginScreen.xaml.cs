using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FlexApp
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var status = User.LogIn.Login(txtUsername.Text, txtPassword.Password);

            if (status == Helper.Message.LoginSuccessful)
            {
                MainWindow.Refresh();
                UserPage.UserPageUserControl.Refresh();
                this.Close();
            }

            if(status == Helper.Message.LoginFailedWrongUsernameOrPassword)
            {
                MessageBox.Show(status);
                txtPassword.Password = "";
                txtUsername.Text = "";
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Windows.OfType<MainWindow>().FirstOrDefault(x => x.IsInitialized).Activate();
        }
    }
}
