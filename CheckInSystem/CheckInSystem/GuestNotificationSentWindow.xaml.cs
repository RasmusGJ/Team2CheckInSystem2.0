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
    /// Interaction logic for NotificationSentWindow.xaml
    /// </summary>
    public partial class GuestNotificationSentWindow : Window
    {
        Controller controller;
        public GuestNotificationSentWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;

        }

        public void GetController(Controller newController)
        {
            controller = newController;
            employeeName.Content = controller.CurrentPersonName;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            Thread.Sleep(10);
            this.Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        { 
            GuestRequestPersonalWindow guestRequestWindow = new GuestRequestPersonalWindow();
            guestRequestWindow.GetController(controller);
            guestRequestWindow.Show();
            Thread.Sleep(10);
            this.Close();
        }
    }
}
