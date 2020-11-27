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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DatabaseConnection;

namespace FlexApp
{
    /// <summary>
    /// Interaction logic for UserPageActiveRentals.xaml
    /// </summary>
    public partial class UserPageActiveRentals : UserControl
    {
        public ObservableCollection<Rental> ActiveMovies { get; set; } = new ObservableCollection<Rental>();

        public UserPageActiveRentals()
        {
            InitializeComponent();

        }

        public void Refresh()
        {
            int index = 0;
            for (int x = 0; x < MovieGrid.ColumnDefinitions.Count; x++)
            {
                if (index < ActiveMovies.Count)
                {
                    Rental m = ActiveMovies[index];

                    StackPanel sp = new StackPanel();
                    TextBlock title = new TextBlock();
                    TextBlock returnDate = new TextBlock();
                    Image image = new Image();

                    title.Cursor = Cursors.Hand;
                    title.Text = $"{m.Movie.Title}";
                    title.FontSize = 18;
                    title.FontWeight = FontWeight.FromOpenTypeWeight(700);
                    title.Foreground = Brushes.White;
                    title.HorizontalAlignment = HorizontalAlignment.Center;
                    title.Margin = new Thickness(5, 5, 5, 0);

                    returnDate.Cursor = Cursors.Hand;
                    returnDate.Text = $"Active until: {m.ReturnDate}";
                    returnDate.FontSize = 12;
                    returnDate.FontStyle = FontStyles.Italic;
                    returnDate.Foreground = Brushes.White;
                    returnDate.HorizontalAlignment = HorizontalAlignment.Center;
                    returnDate.Margin = new Thickness(5, 5, 5, 8);

                    image.Cursor = Cursors.Hand;
                    image.Source = new BitmapImage(new Uri(m.Movie.PosterLink));
                    image.MaxHeight = 210;

                    sp.Children.Add(title);
                    sp.Children.Add(returnDate);
                    sp.Children.Add(image);
                    
                    MovieGrid.Children.Add(sp);

                    sp.MouseUp += Mouse_Up;

                    Grid.SetColumn(sp, x);

                    index++;
                }
            }
        }

        private void Mouse_Up(object sender, MouseButtonEventArgs e)
        {
            var x = Grid.GetColumn(sender as UIElement);

        }
    }
}
