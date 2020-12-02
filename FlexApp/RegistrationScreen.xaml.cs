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
        private string AvatarPath { get; set; }

        public RegistrationScreen()
        {
            InitializeComponent();

            // Vacker standard Avatar
            Avatar.Source = new BitmapImage(new Uri(Helper.Image.BjornAvatarURL));
        }

        private void New_Registration_Button_Click(object sender, RoutedEventArgs e)
        {
            // Kollar så Username och password är 4+ långt
            if(New_Username.Text.Length < 4 || New_Password.Password.Length < 4) 
            { 
                MessageBox.Show(Helper.Message.RegistrationErrorUsernamePasswordIncorect); 
                New_Username.Text = "";
                New_Password.Password = "";
                Repeat_Password.Password = "";
                return;
            }

            // Kollar så lösenorden matchar
            if (New_Password.Password != Repeat_Password.Password) 
            { 
                MessageBox.Show(Helper.Message.RegistrationErrorPasswordMismatch);
                New_Password.Password = "";
                Repeat_Password.Password = "";
                return;
            }

            // Kollar så username inte redan är taget
            if (Status.ct.Logins.Where(l => l.Username.Equals(New_Username)).Count() > 0) 
            { 
                MessageBox.Show(Helper.Message.RegistrationErrorUsernameAlreadyExists);
                New_Username.Text = "";
                New_Password.Password = "";
                Repeat_Password.Password = "";
                return;
            }

            // Kollar så email inte redan finns registrerad
            if (Status.ct.Customers.Where(c => c.Email.Equals(New_Email.Text)).Count() > 0) 
            { 
                MessageBox.Show(Helper.Message.RegistrationErrorEmailAlreadyRegistered);
                New_Username.Text = "";
                New_Password.Password = "";
                Repeat_Password.Password = "";
                return; 
            }

            // Kollar så Postal Code är i rätt format
            string postalCode = String.Concat(New_Postal.Text
                .Select(c => c = !Char.IsDigit(c) ? ' ' : c)
                .SkipWhile(x => Char.IsWhiteSpace(x)));
            try { postalCode = postalCode.Insert(3, " "); }
            catch {
                MessageBox.Show(Helper.Message.RegistrationErrorInvalidPostal);
                New_Postal.Text = "";
                return;
            }
            if(postalCode.Length > 6)
            {
                MessageBox.Show(Helper.Message.RegistrationErrorInvalidPostal);
                New_Postal.Text = "";
                return;
            }

            // Kollar så Email är i rätt format
            List<bool> check = new List<bool>();
            string email = New_Email.Text;
            int iAt = email.IndexOf('@');
            int iDot = email.IndexOf('.');

            if (!email.Contains('@') && !email.Contains('.')) check.Add(false);
            if (email.Where(c => c == '@').Count() > 1 || email.Where(c => c == '.').Count() > 1) check.Add(false);
            if (iAt > iDot) check.Add(false);
            if (email.Replace('@', 'X').Replace('.', 'X').Where(c => !Char.IsLetterOrDigit(c)).Count() > 0) check.Add(false);
            if (iAt < 1 || iDot - iAt < 1 || email.Length - iDot < 2) check.Add(false);
            if (check.Contains(false)) 
            {
                MessageBox.Show(Helper.Message.RegistrationErrorEmailWrongFormat);
                New_Email.Text = "";
                return;
            }

            string adress = $"{New_Street.Text} {postalCode} {New_City.Text} {New_State.Text}";

            User.CreateUser.CreateNewUser(
                New_FirstName.Text, New_LastName.Text,
                New_Email.Text, adress, New_PhoneNo.Text,
                New_Username.Text, New_Password.Password,
                AvatarPath
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
            Repeat_Password.Password = "";

            UserPage.UserPageUserControl.AvatarImage.Source = new BitmapImage(new Uri(Helper.Image.BjornAvatarURL));
            this.Visibility = Visibility.Hidden;

        }

        private void Upload_Avatar_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            // Om den inte hittar mydocuments funkar denna istället -> System.IO.Path.GetFullPath(Environment.GetEnvironmentVariable("Home") + @"\.ssh");
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dlg.DefaultExt = ".jpg";
            dlg.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*jpg|All files (*.*)|*.*";

            bool? result = dlg.ShowDialog();

            if(result == true)
            {
                try
                {
                    Avatar.Source = new BitmapImage(new Uri(dlg.FileName));
                    AvatarPath = dlg.FileName;
                }
                catch
                {
                    MessageBox.Show(Helper.Message.AvatarFailedToLoad);
                }            
            }                                      
        }
    }
}
