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
using Microsoft.Win32;

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

            // lägg till avatar i databas
            // uppdatera avatar när man loggar in / byter bild
            Avatar.Source = new BitmapImage(new Uri(Helper.Image.BjornAvatarURL));

        }

        private void New_Registration_Button_Click(object sender, RoutedEventArgs e)
        {

            if(New_Username.Text.Length < 4 || New_Password.Password.Length < 4) 
            { 
                MessageBox.Show(Helper.Message.RegistrationErrorUsernameLength); 
                New_Username.Text = "";
                return;
            }

            if (New_Password.Password != Repeat_Password.Password) 
            { 
                MessageBox.Show(Helper.Message.RegistrationErrorPasswordMismatch);
                New_Password.Password = "";
                return;
            }

            if (Status.ct.Logins.Where(l => l.Username.Equals(New_Username)).Count() > 0) 
            { 
                MessageBox.Show(Helper.Message.RegistrationErrorUsernameAlreadyExists);
                return;
            }

            if (Status.ct.Customers.Where(c => c.Email.Equals(New_Email.Text)).Count() > 0) 
            { 
                MessageBox.Show(Helper.Message.RegistrationErrorEmailAlreadyRegistered); 
                return; 
            }

            string adress = $"{New_Street.Text} {New_Postal.Text} {New_City.Text} {New_State.Text}";

            User.CreateUser.CreateNewUser(
                New_FirstName.Text, New_LastName.Text,
                New_Email.Text, adress, New_PhoneNo.Text,
                New_Username.Text, New_Password.Password
                // Avatar.Source.ToString()
                ) ;

            New_FirstName.Text = "";
            New_LastName.Text = "";
            New_Street.Text = "";
            New_Postal.Text = "";
            New_City.Text = "";
            New_State.Text = "";
            New_Email.Text = "";
            New_PhoneNo.Text = "";
            New_Username.Text = "";
            New_Password.Password = "";

        }

        private void Upload_Avatar_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = System.IO.Path.GetFullPath(Environment.GetEnvironmentVariable("Home") + @"\.ssh");
            dlg.DefaultExt = ".jpg";
            dlg.Filter = "Image files(*.jpg) | *.jpg | All Files(*.*) | *.* ";

            bool? result = dlg.ShowDialog();

            if(result == true)
            {
                Avatar.Source = new BitmapImage(new Uri(dlg.FileName));
            }
            else if(result != null) MessageBox.Show(Helper.Message.AvatarFailedToLoad);
                                                       
        }
    }
}
