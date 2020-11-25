﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DatabaseConnection;

namespace FlexApp
{
    /// <summary>
    /// Interaction logic for MovieDetailRental.xaml
    /// </summary>
    public partial class MovieFocus : Window
    {

        public ObservableCollection<DaysActiveComboBox> DaysActiveSelection { get {
            return new ObservableCollection<DaysActiveComboBox>() { 
            new DaysActiveComboBox(1),
            new DaysActiveComboBox(3),
            new DaysActiveComboBox(7)
            }; }
        }

        public class DaysActiveComboBox
        {
            public int DaysActive { get; set; }
            public DaysActiveComboBox(int i) { DaysActive = i; }

        }

        public int DaysActiveSelected { get; set; }

        public Movie MovieSelected { get; set; }

        public MovieFocus()
        {
            InitializeComponent();

            DataContext = this;
            
        }

        private void Rent_Button_Click(object sender, RoutedEventArgs e)
        {
            if(!Status.IsLoggedIn)
            {
                //LoginScreen ls = new LoginScreen();
                //ls.Show();
            }

            if(Status.IsLoggedIn)
            {
                try
                {
                    new User.Rental(MovieSelected).Execute(DaysActiveSelected);

                    MessageBox.Show("Rental osv");
                }
                catch(Exception er) 
                {
                    MessageBox.Show("du suger osv, jupp" + er);
                }

                this.Close();
            }
        }

        private void DaysActiveSelectionMjo_DropDownClosed(object sender, EventArgs e)
        {
            DaysActiveSelected = Int32.Parse(DaysActiveSelectionMjo.Text);
        }
    }
}
