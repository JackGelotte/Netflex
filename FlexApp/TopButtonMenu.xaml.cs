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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlexApp
{
    /// <summary>
    /// Interaction logic for TopButtonMenu.xaml
    /// </summary>
    public partial class TopButtonMenu : UserControl
    {
        public TopButtonMenu()
        {
            InitializeComponent();

            if(!MainWindow.CurrentSession.IsLoggedIn)
            {
                LeftButtom.Text = "Login";
                RightButton.Text = "Register";
            }

            if(MainWindow.CurrentSession.IsLoggedIn)
            {
                LeftButtom.Text = "Log Out";
                RightButton.Text = "My Page";
            }
        }

        private void Left_Click(object sender, RoutedEventArgs e)
        {
            if (!MainWindow.CurrentSession.IsLoggedIn)
            {
                LoginScreen ls = new LoginScreen();
                ls.Show();
            }

            if (MainWindow.CurrentSession.IsLoggedIn)
            {

            }
        }

        private void Right_Click(object sender, RoutedEventArgs e)
        {
            if (!MainWindow.CurrentSession.IsLoggedIn)
            {

            }

            if (MainWindow.CurrentSession.IsLoggedIn)
            {

            }
        }
    }
}
