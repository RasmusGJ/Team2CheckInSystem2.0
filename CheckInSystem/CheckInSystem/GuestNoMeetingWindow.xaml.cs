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
    /// Interaction logic for NoReservationWindow.xaml
    /// </summary>
    public partial class GuestNoMeetingWindow : Window
    {
        Controller controller;
        public GuestNoMeetingWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
        }
        public void GetController(Controller newController)
        {
            controller = newController;
        }

        private void GoToGuestRequestWindow(object sender, RoutedEventArgs e)
        {
            GuestRequestPersonalWindow guestRequestWindow = new GuestRequestPersonalWindow();
            guestRequestWindow.GetController(controller);
            guestRequestWindow.Show();
            Thread.Sleep(10);
            this.Close();
        }

        private void GoToCoffeeDrinkerWindow(object sender, RoutedEventArgs e)
        {
            GuestNoPurposeWindow coffeeDrinkerWindow = new GuestNoPurposeWindow();
            coffeeDrinkerWindow.GetController(controller);
            coffeeDrinkerWindow.Show();
            Thread.Sleep(10);
            this.Close();
        }
    }
}
