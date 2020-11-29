﻿using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class AutoCompleteTextBoxUserControl : UserControl
    {        
        public AutoCompleteTextBoxUserControl()
        {
            this.InitializeComponent();

            this.SearchBox.Text = Helper.Message.SearchBoxText;
        }

        private List<string> autoSuggestionList = Status.ct.Movies.Select(m => m.Title).ToList();
        public List<string> AutoSuggestionList
        {
            get { return this.autoSuggestionList; }
            set { this.autoSuggestionList = value; }
        }

        private void OpenAutoSuggestionBox()
        {
            this.autoListPopup.Visibility = Visibility.Visible;
            this.autoListPopup.IsOpen = true;
            this.autoList.Visibility = Visibility.Visible;
        }

        private void CloseAutoSuggestionBox()
        {
            this.autoListPopup.Visibility = Visibility.Collapsed;
            this.autoListPopup.IsOpen = false;
            this.autoList.Visibility = Visibility.Collapsed;
        }

        private void AutoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.SearchBox.Text))
            {
                this.CloseAutoSuggestionBox();
                this.autoList.ItemsSource = this.AutoSuggestionList.Where(p => p.Contains(this.SearchBox.Text, StringComparison.OrdinalIgnoreCase)).ToList();
                Movies.LoadPopularMovies();
                MovieDisplay.MovieDisplayUserControl.Page = 0;
                MovieDisplay.MovieDisplayUserControl.Index = 0;
                MovieDisplay.Refresh();
                return;
            }

            if (!(e.Changes.Where(c=>c.RemovedLength > 0).Count() > 0))
            {
                if (this.SearchBox.Text != Helper.Message.SearchBoxText)
                {
                    this.OpenAutoSuggestionBox();
                    this.autoList.ItemsSource = this.AutoSuggestionList.Where(p => p.Contains(this.SearchBox.Text, StringComparison.OrdinalIgnoreCase)).ToList();
                    Movies.SearchMovie(SearchBox.Text);
                    MovieDisplay.MovieDisplayUserControl.Page = 0;
                    MovieDisplay.MovieDisplayUserControl.Index = 0;
                    MovieDisplay.Refresh();
                }
            }
        }

        private void AutoList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.autoList.SelectedIndex <= -1)
            {
                this.CloseAutoSuggestionBox();
                return;
            }
            this.CloseAutoSuggestionBox();

            this.SearchBox.Text = this.autoList.SelectedItem.ToString();
            this.autoList.SelectedIndex = -1;
        }

        private void SearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SearchBox.Text == Helper.Message.SearchBoxText) SearchBox.Text = "";
            OpenAutoSuggestionBox();
        }

        private void SearchBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(SearchBox.Text))
            {
                SearchBox.Text = Helper.Message.SearchBoxText;
                CloseAutoSuggestionBox();
            }
        }
    }
}
