﻿using System;
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
using DatabaseConnection;

namespace FlexApp
{
    /// <summary>
    /// Interaction logic for Franco1.xaml
    /// </summary>
    public partial class Franco1 : Page
    {

        public Franco1()
        {
            InitializeComponent();

            for (int x = 0; x < MovieGrid.ColumnDefinitions.Count; x++)
            {
                for (int y = 0; y < MovieGrid.RowDefinitions.Count; y++)
                {
                     Movie m = MovieViewer.DisplayMovies.Dequeue();
                    
                     Image image = new Image();
                     image.Cursor = Cursors.Hand;
                     image.HorizontalAlignment = HorizontalAlignment.Center;
                     image.VerticalAlignment = VerticalAlignment.Center;

                     image.Source = new BitmapImage(new Uri(GetImdbInfo.ImdbPoster(m)));

                     image.Margin = new Thickness(4, 4, 4, 4);

                     MovieGrid.Children.Add(image);
                     Grid.SetRow(image, y);
                     Grid.SetColumn(image, x);
                    

                }
            }

        }

        private void Click_Previous(object sender, RoutedEventArgs e)
        {
            if (MovieViewer.HoldPrevious.Count > 0)
            {
                for (int x = 0; x < MovieGrid.ColumnDefinitions.Count; x++)
                {
                    for (int y = 0; y < MovieGrid.RowDefinitions.Count; y++)
                    {




                    }
                }
            }

        }

        private void Click_Next(object sender, RoutedEventArgs e)
        {
            if(MovieViewer.DisplayMovies.Count > 0)
            {
                for (int x = 0; x < MovieGrid.ColumnDefinitions.Count; x++)
                {
                    for (int y = 0; y < MovieGrid.RowDefinitions.Count; y++)
                    {




                    }
                }

            }

        }
    }
}
