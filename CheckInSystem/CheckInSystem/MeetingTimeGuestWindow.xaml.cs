using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CheckInSystem.Application_Layer;

namespace CheckInSystem
{
    /// <summary>
    /// Interaction logic for MeetingTimeGuestWindow.xaml
    /// </summary>
    public partial class MeetingTimeGuestWindow : Window
    {
        public Controller controller;
        public MeetingTimeGuestWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
        }
        public void GetController(Controller newController)
        {
            controller = newController;
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            AnnounceArrivalWindow announceArrivalWindow = new AnnounceArrivalWindow();
            announceArrivalWindow.Show();
            Thread.Sleep(10);
            this.Close();
        }
    }
}
