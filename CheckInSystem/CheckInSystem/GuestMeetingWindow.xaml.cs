﻿using System;
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
    public partial class GuestMeetingWindow : Window
    {
        public Controller controller;
        public GuestMeetingWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
        }
        // GetController pulls the controller from the previous window with all the saved information
        // Regarding the guest and the person booking
        public void GetController(Controller newController)
        {
            controller = newController;
            welcomeLabel.Content = "Welcome " + controller.CurrentPersonName;
            timeLabel.Content = "At " + controller.appointmentRepo.currentAppointment.FromTime.ToString("HH:mm dd-MM-yyyy");
            controller.appointmentRepo.GetBookerInfo();
            nameLabel.Content = controller.appointmentRepo.currentAppointment.Booker.Name;
            roleLabel.Content = controller.appointmentRepo.currentAppointment.Booker.Role;
            departmentLabel.Content = controller.appointmentRepo.currentAppointment.Booker.Department;
        }
        // Goes to the previous window, GuestArrivalWindow
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            GuestArrivalWindow guestArrivalWindow = new GuestArrivalWindow();
            guestArrivalWindow.Show();
            Thread.Sleep(10);
            this.Close();
        }
        // Goes to MainWindow
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            Thread.Sleep(10);
            this.Close();
        }
    }
}
