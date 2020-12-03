﻿using System;
using System.Linq;
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

    public partial class MovieFocus : Window
    {
        public ObservableCollection<DaysActiveComboBox> DaysActiveSelection { get {
            return new ObservableCollection<DaysActiveComboBox>() { 
            new DaysActiveComboBox(Helper.Message.RentalSelectedActiveDays),
            new DaysActiveComboBox("1"),
            new DaysActiveComboBox("3"),
            new DaysActiveComboBox("7")
            }; }
        }

        public class DaysActiveComboBox
        {
            public string DaysActive { get; set; }
            public DaysActiveComboBox(string i) { DaysActive = i; }
            
        }

        public int DaysActiveSelected { get; set; } = -1;

        public Movie MovieSelected { get; set; }

        public MovieFocus()
        {
            InitializeComponent();

            DataContext = this;

            TrailerRun.InitializeComponent();
        }

        private void Rent_Button_Click(object sender, RoutedEventArgs e)
        {
            if(!Status.IsLoggedIn)
            {
                Login.Visibility = Visibility.Visible;
                return;
            }

            if (Status.IsLoggedIn && DaysActiveSelected < 1) MessageBox.Show(Helper.Message.RentalSelectActiveDaysError);

            if (Status.IsLoggedIn && DaysActiveSelected > 0) 
            {
                PaymentWindow payment = new PaymentWindow(MovieSelected, DaysActiveSelected);
                MainWindow mw = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault(x => x.IsInitialized);
                payment.Owner = mw;
                payment.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                payment.ShowDialog();
            }
        }

        private void DaysActiveSelectionMjo_DropDownClosed(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(DaysActiveSelectionMjo.Text))

                try
                {
                    Int32.TryParse(DaysActiveSelectionMjo.Text, out int test);
                    DaysActiveSelected = test;
                }

                catch { DaysActiveSelected = -1; }                   
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Windows.OfType<MainWindow>().FirstOrDefault(x => x.IsInitialized).Activate();
        }

    }
}
