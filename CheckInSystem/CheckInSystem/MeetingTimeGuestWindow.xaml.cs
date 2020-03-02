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
    /// Interaction logic for MeetingTimeGuestWindow.xaml
    /// </summary>
    public partial class MeetingTimeGuestWindow : Window
    {
        public MeetingTimeGuestWindow()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            AnnounceArrivalWindow announceArrivalWindow = new AnnounceArrivalWindow();
            announceArrivalWindow.Show();
            this.Close();
        }
    }
}
