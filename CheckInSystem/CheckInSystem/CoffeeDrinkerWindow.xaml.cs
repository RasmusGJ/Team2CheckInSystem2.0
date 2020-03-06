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
using System.Threading;
using CheckInSystem.Application_Layer;

namespace CheckInSystem
{
    /// <summary>
    /// Interaction logic for CoffeeDrinkerWindow.xaml
    /// </summary>C:\Users\jacob\Documents\GitHub\Team2CheckInSystem2.0\CheckInSystem\CheckInSystem\CoffeeDrinkerWindow.xaml.cs
    public partial class CoffeeDrinkerWindow : Window
    {
        Controller controller;
        public CoffeeDrinkerWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
        }
        public void GetController(Controller newController)
        {
            controller = newController;
            guestName.Content = controller.CurrentPersonName;
        }
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NoReservationWindow noReservationWindow = new NoReservationWindow();
            noReservationWindow.GetController(controller);
            noReservationWindow.Show();
            Thread.Sleep(10);
            this.Close();
        }

        private void Click_Ok(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Thread.Sleep(10);
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Thread.Sleep(10);
            this.Close();
        }
    }
}
