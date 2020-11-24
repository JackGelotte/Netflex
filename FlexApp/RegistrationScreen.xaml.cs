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

        public void Register_Click(object sender, MouseButtonEventArgs e)
        {
            bool check = false;
            while(!check)
            {
                if (New_Password.Password != Repeat_Password.Password)
                {
                    MessageBox.Show(Helper.Message.RegistrationErrorPasswordMismatch);
                    continue;
                }

                if (UserSession.ct.Logins.Where(l => l.Username.Equals(New_Username)).Count() > 0)
                {
                    MessageBox.Show(Helper.Message.RegistrationErrorUsernameAlreadyExists);
                    continue;
                }

                if(UserSession.ct.Customers.Where(c => c.Email.Equals(New_Email.Text)).Count() > 0)
                {
                    MessageBox.Show(Helper.Message.RegistrationErrorEmailAlreadyRegistered);
                    continue;
                }

                User.UserCreation.CreateNewUser(New_FirstName.Text, New_LastName.Text, New_Email.Text, New_Adress.Text, "070", New_Username.Text, New_Password.Password);

            }

             

        }


    }
}
