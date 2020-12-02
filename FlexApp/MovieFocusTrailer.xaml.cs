using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TMDbLib;

namespace FlexApp
{
    /// <summary>
    /// Interaction logic for MovieFocusTrailer.xaml
    /// </summary>
    public partial class MovieFocusTrailer : UserControl
    {
        public MovieFocusTrailer()
        {
            InitializeComponent();

            Trailer.Source = new Uri("c:/inception.mp4");

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

            Status.Content = "00:00 / 00:00";
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (Trailer.Source != null)
            {
                if (Trailer.NaturalDuration.HasTimeSpan)
                {
                    Status.Content = String.Format($"{Trailer.Position.ToString(@"mm\:ss")} / {Trailer.NaturalDuration.TimeSpan.ToString(@"mm\:ss")}");
                }
            }
            else
            {
                Status.Content = Helper.Message.TrailerErrorLoading;
            }
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            Trailer.Stop();
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            Trailer.Play();
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            Trailer.Pause();
        }
    }
}
