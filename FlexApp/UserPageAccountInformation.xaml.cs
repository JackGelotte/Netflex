﻿using Microsoft.Win32;
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
    /// Interaction logic for UserPageAccountInformation.xaml
    /// </summary>
    public partial class UserPageAccountInformation : UserControl
    {
        private string AvatarUrl { get; set; }

        public UserPageAccountInformation()
        {
            InitializeComponent();
        }

        private void Adress_Save_Changes_Click(object sender, RoutedEventArgs e)
        {
            string adress = $"{Street.Text} {Postal.Text} {City.Text} {State.Text}";
            Status.Customer.Adress = adress;
            Status.ct.Update(Status.Customer);
            Status.ct.SaveChanges();
            UserPage.UserPageUserControl.Refresh();
        }

        private void UserInfo_Save_Changes_Click(object sender, RoutedEventArgs e)
        {

            if (Username.Text != Status.Customer.Login.Username &&(Username.Text.Length < 4 || Password.Password.Length < 4))
            {
                MessageBox.Show(Helper.Message.RegistrationErrorUsernamePasswordIncorect);
                Username.Text = "";
                return;
            }

            if (Password.Password != PasswordRepeat.Password)
            {
                MessageBox.Show(Helper.Message.RegistrationErrorPasswordMismatch);
                Password.Password = "";
                PasswordRepeat.Password = "";
                return;
            }

            if (Status.ct.Logins.Where(l => l.Username.Equals(Username)).Count() > 0)
            {
                MessageBox.Show(Helper.Message.RegistrationErrorUsernameAlreadyExists);
                return;
            }

            if (Email.Text != Status.Customer.Email && (Status.ct.Customers.Where(c => c.Email.Equals(Email.Text)).Count() > 0))
            {
                MessageBox.Show(Helper.Message.RegistrationErrorEmailAlreadyRegistered);
                return;
            }

            Status.Customer.Email = Email.Text;
            Status.Customer.Login.Username = Username.Text;
            Status.Customer.Login.Password = User.CreateUser.Encrypt(Password.Password);
            
            Status.ct.Update(Status.Customer);
            Status.ct.Update(Status.Customer.Login);
            Status.ct.SaveChanges();
            UserPage.UserPageUserControl.Refresh();
        }

        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            // Om den inte hittar mydocuments funkar denna istället -> System.IO.Path.GetFullPath(Environment.GetEnvironmentVariable("Home") + @"\.ssh");
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dlg.DefaultExt = ".jpg";
            dlg.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*jpg|All files (*.*)|*.*";

            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                try
                {
                    Avatar.Source = new BitmapImage(new Uri(dlg.FileName));
                    this.AvatarUrl = dlg.FileName;
                }
                catch
                {
                    MessageBox.Show(Helper.Message.AvatarFailedToLoad);
                }
            }
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            Status.Customer.AvatarUrl = this.AvatarUrl;
            Status.ct.Update(Status.Customer);
            Status.ct.SaveChanges();
            UserPage.UserPageUserControl.Refresh();
        }
    }
}
