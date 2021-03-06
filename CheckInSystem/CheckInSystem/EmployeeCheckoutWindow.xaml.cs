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
    /// Interaction logic for EmployeeCheckoutWindow.xaml
    /// </summary>
    public partial class EmployeeCheckoutWindow : Window
    {
        Controller controller;
        public EmployeeCheckoutWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
        }

        // Prepares the GetController method so we uphold the same data throughout the program
        public void GetController(Controller newController)
        {
            controller = newController;
            nameText.Text = controller.CurrentPerson.Name;
        }
        // Goes to MainWindow
        private void GoToMainWindow(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Thread.Sleep(10);
            this.Close();
        }

    }
}
