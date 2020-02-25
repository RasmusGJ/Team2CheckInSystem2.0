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

        public void GetController(Controller newController)
        {
            controller = newController;
            //MessageBox.Show(newController.CurrentPerson.Name);

            nameText.Text = controller.CurrentPerson.Name;
        }

        private void GoToMainWindow(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MoodWindow moodWindow = new MoodWindow();
            moodWindow.GetController(controller);
            moodWindow.Show();
            this.Close();
        }
    }
}
