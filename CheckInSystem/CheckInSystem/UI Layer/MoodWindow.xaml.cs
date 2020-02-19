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
    /// Interaction logic for MoodWindow.xaml
    /// </summary>
    public partial class MoodWindow : Window
    {
        public MoodWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
        }

        private void SadSelect(object sender, RoutedEventArgs e)
        {
            EmployeeWelcomeWindow welcomeWindow = new EmployeeWelcomeWindow();
            welcomeWindow.Show();
            this.Close();
        }

        private void NeutralSelect(object sender, RoutedEventArgs e)
        {
            EmployeeWelcomeWindow welcomeWindow = new EmployeeWelcomeWindow();
            welcomeWindow.Show();
            this.Close();
        }

        private void HappySelect(object sender, RoutedEventArgs e)
        {
            EmployeeWelcomeWindow welcomeWindow = new EmployeeWelcomeWindow();
            welcomeWindow.Show();
            this.Close();
        }
    }
}
