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
    /// Interaction logic for AnnounceArrivalWindow.xaml
    /// </summary>
    public partial class AnnounceArrivalWindow : Window
    {
        public AnnounceArrivalWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            this.Close();
        }

        private void Ok_Button(object sender, RoutedEventArgs e)
        {
            GuestRequestWindow guestRequestWindow = new GuestRequestWindow();
            guestRequestWindow.Show();
            this.Close();
        }

    }
}
