using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CheckInSystem.Domain_Layer;
using System.Threading;
using CheckInSystem.Application_Layer;

namespace CheckInSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Controller controller = new Controller();
        public MainWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
        }

        /// Goes to EmployeePincodeWindow
        private void GoToPinCodeWindow(object sender, RoutedEventArgs e)
        {
            rectangleRed.Fill = new SolidColorBrush(Color.FromRgb(254,24,24));
            EmployeePinCodeWindow pinWindow = new EmployeePinCodeWindow();
            pinWindow.GetController(controller);
            pinWindow.Show();
            Thread.Sleep(10);
            this.Close();
        }
        /// Goes to GuestArrivalWindow
        private void GoToGuestArrivalWindow(object sender, RoutedEventArgs e)
        {
            GuestArrivalWindow arrivalWindow = new GuestArrivalWindow();
            arrivalWindow.GetController(controller);
            arrivalWindow.Show();
            Thread.Sleep(10);
            this.Close();
        }
    }
}
