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
using System.Windows.Shapes;
using CheckInSystem.Application_Layer;
using CheckInSystem.Domain_Layer;


namespace CheckInSystem
{
    /// <summary>
    /// Interaction logic for AnnounceArrivalWindow.xaml
    /// </summary>
    public partial class AnnounceArrivalWindow : Window
    {
        public AnnounceArrivalWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            GuestRepo guestRepo = new GuestRepo();
            DataContext = guestRepo;
            listView.ItemsSource = guestRepo.guests;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listView.ItemsSource);
            view.Filter = UserFilter;
        }
        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(nameBox.Text) && String.IsNullOrEmpty(compBox.Text))
                return true;

            else if (String.IsNullOrEmpty(compBox.Text) == false && String.IsNullOrEmpty(nameBox.Text))
                return ((item as Guest).Company.IndexOf(compBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);

            else if (String.IsNullOrEmpty(nameBox.Text) == false && String.IsNullOrEmpty(compBox.Text))
                return ((item as Guest).Name.IndexOf(nameBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);

            else
                return ((item as Guest).Name.IndexOf(nameBox.Text, StringComparison.OrdinalIgnoreCase) >= 0 &&
                    (item as Guest).Company.IndexOf(compBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(listView.ItemsSource).Refresh();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            this.Close();
        }

        private void Ok_Button(object sender, RoutedEventArgs e)
        {
            NoReservationWindow noReservationWindow = new NoReservationWindow();
            noReservationWindow.Show();
            this.Close();
        }

    }
}
