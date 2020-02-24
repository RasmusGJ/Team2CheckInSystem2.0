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
        public void GetController(Controller newController)
        {
            controller = newController;
            MessageBox.Show(newController.CurrentPerson.Name);

            nameText.Text = controller.CurrentPerson.Name;


        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mainWindow.Show();
            this.Close();
        }
    }
}
