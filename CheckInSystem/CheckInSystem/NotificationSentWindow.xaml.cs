using System;
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
    /// Interaction logic for NotificationSentWindow.xaml
    /// </summary>
    public partial class NotificationSentWindow : Window
    {
        public NotificationSentWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            this.Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NoReservationWindow noReservationWindow = new NoReservationWindow();
            noReservationWindow.Show();
            this.Close();
        }
    }
}
