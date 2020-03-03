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

namespace CheckInSystem
{
    /// <summary>
    /// Interaction logic for CoffeeDrinkerWindow.xaml
    /// </summary>
    public partial class CoffeeDrinkerWindow : Window
    {
        public CoffeeDrinkerWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NoReservationWindow noReservationWindow = new NoReservationWindow();
            noReservationWindow.Show();
            this.Close();
        }

        private void Click_Ok(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
