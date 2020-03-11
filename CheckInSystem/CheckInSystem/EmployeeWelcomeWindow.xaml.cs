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
using CheckInSystem.Application_Layer;
using System.Threading;

namespace CheckInSystem
{
    /// <summary>
    /// Interaction logic for EmployeeWelcomeWindow.xaml
    /// </summary>
    /// 

    public partial class EmployeeWelcomeWindow : Window
    {
        Controller controller;

        public EmployeeWelcomeWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
        }
        // Gets the controller from the previous window, so the same data is uphold 
        public void GetController(Controller newController)
        {
            controller = newController;
            nameText.Text = controller.CurrentPerson.Name;
        }
        // Goes to MainWindow
        private void GoToMainWindow(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mainWindow.Show();
            Thread.Sleep(10);
            this.Close();
        }
    }
}
