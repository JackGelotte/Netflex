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

namespace FlexApp
{
    /// <summary>
    /// Interaction logic for RegistrationScreen.xaml
    /// </summary>
    public partial class RegistrationScreen : UserControl
    {
        public RegistrationScreen()
        {
            InitializeComponent();
        }

        private void New_Registration_Button_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("fef");
            bool check = true;
            while (check)
            {
                if(New_Username.Text.Length < 4 || New_Password.Password.Length < 4) 
                    { MessageBox.Show(Helper.Message.LoginFailedWrongUsernameOrPassword); break; }

                if (New_Password.Password != Repeat_Password.Password) 
                    { MessageBox.Show(Helper.Message.RegistrationErrorPasswordMismatch); break; ; }

                if (Status.ct.Logins.Where(l => l.Username.Equals(New_Username)).Count() > 0) 
                    { MessageBox.Show(Helper.Message.RegistrationErrorUsernameAlreadyExists); break; ; }

                if (Status.ct.Customers.Where(c => c.Email.Equals(New_Email.Text)).Count() > 0) 
                    { MessageBox.Show(Helper.Message.RegistrationErrorEmailAlreadyRegistered); break; ; }

                User.CreateUser.CreateNewUser(
                    New_FirstName.Text, New_LastName.Text, 
                    New_Email.Text, New_Adress.Text, "070", 
                    New_Username.Text, New_Password.Password
                    );

                check = false;
            }
        }
    }
}
