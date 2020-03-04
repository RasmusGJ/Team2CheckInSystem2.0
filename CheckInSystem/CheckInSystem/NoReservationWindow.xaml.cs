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

namespace CheckInSystem
{
    /// <summary>
    /// Interaction logic for NoReservationWindow.xaml
    /// </summary>
    public partial class NoReservationWindow : Window
    {
        public NoReservationWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
        }
        public void GetPerson()
        {

        }

        private void GoToGuestRequestWindow(object sender, RoutedEventArgs e)
        {
            GuestRequestWindow guestRequestWindow = new GuestRequestWindow();
            guestRequestWindow.Show();
            Thread.Sleep(10);
            this.Close();
        }

        private void GoToCoffeeDrinkerWindow(object sender, RoutedEventArgs e)
        {
            CoffeeDrinkerWindow coffeeDrinkerWindow = new CoffeeDrinkerWindow();
            coffeeDrinkerWindow.Show();
            Thread.Sleep(10);
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
