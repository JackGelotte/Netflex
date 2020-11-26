using System;
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
       // public MainWindow Sender { get; set; }

        public LoginScreen(MainWindow mw)
        {
            InitializeComponent();
        }

        public LoginScreen()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var status = User.LogIn.Login(txtUsername.Text, txtPassword.Password);

            MessageBox.Show(status);

            if (status == Helper.Message.LoginSuccessful)
            {
                MainWindow.Refresh();
                this.Close();
            }

            if(status == Helper.Message.LoginFailedWrongUsernameOrPassword)
            {
                txtPassword.Password = "";
                txtUsername.Text = "";
            }

        }
    }
}
