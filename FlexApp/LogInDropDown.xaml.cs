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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace FlexApp
{
    /// <summary>
    /// Interaction logic for LogInDropDown.xaml
    /// </summary>
    public partial class LogInDropDown : UserControl
    {
        public LogInDropDown()
        {
            InitializeComponent();

            this.IsVisibleChanged += new DependencyPropertyChangedEventHandler(LoginControl_IsVisibleChanged);
        }

        void LoginControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue == true)
            {
                Dispatcher.BeginInvoke(DispatcherPriority.ContextIdle, new Action(delegate ()
                {
                    txtUsername.Focus();
                }));
            }
        }

        private void UserControl_LostFocus(object sender, RoutedEventArgs e)
        {
            if(Application.Current.Windows.OfType<MainWindow>().FirstOrDefault(x => x.IsInitialized).IsFocused)
            {
                this.Visibility = Visibility.Hidden;
            }       
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var status = User.LogIn.Login(txtUsername.Text, txtPassword.Password);

            if (status == Helper.Message.LoginSuccessful)
            {
                MainWindow.Refresh();
                UserPage.UserPageUserControl.Refresh();
                txtPassword.Password = "";
                txtUsername.Text = "";
                this.Visibility = Visibility.Hidden;
            }

            if (status == Helper.Message.LoginFailedWrongUsernameOrPassword)
            {
                MessageBox.Show(status);
                txtPassword.Password = "";
                txtUsername.Text = "";
            }
        }
    }
}
