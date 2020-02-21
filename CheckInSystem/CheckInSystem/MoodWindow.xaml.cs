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
using CheckInSystem.Domain_Layer;

namespace CheckInSystem
{
    /// <summary>
    /// Interaction logic for MoodWindow.xaml
    /// </summary>
    public partial class MoodWindow : Window
    {
        Controller controller = new Controller();
        CheckInRepo checkInRepo = new CheckInRepo();

        public MoodWindow()
        {

            InitializeComponent();
            WindowState = WindowState.Maximized;
                  
            if (checkInRepo.CheckIfCheckedIn(controller.CurrentPerson) == true)
            {
                checkOutButton.Visibility = Visibility.Visible;
            }
            else
                checkOutButton.Visibility = Visibility.Hidden;
        }

        public void GetController(Controller newController)
        {
            controller = newController;
            MessageBox.Show(newController.CurrentPerson.Name);

            nameLabel.Content = controller.CurrentPerson.Name;
            
        }

        private void SadSelect(object sender, RoutedEventArgs e)
        {
            controller.AssignMood(Mood.Negative);
            EmployeeWelcomeWindow welcomeWindow = new EmployeeWelcomeWindow();
            welcomeWindow.Show();
            this.Close();
        }

        private void NeutralSelect(object sender, RoutedEventArgs e)
        {
            controller.AssignMood(Mood.Neutral);
            EmployeeWelcomeWindow welcomeWindow = new EmployeeWelcomeWindow();
            welcomeWindow.Show();
            this.Close();
        }

        private void HappySelect(object sender, RoutedEventArgs e)
        {
            controller.AssignMood(Mood.Positive);
            EmployeeWelcomeWindow welcomeWindow = new EmployeeWelcomeWindow();
            welcomeWindow.Show();
            this.Close();
        }

        private void checkOutButton_Click_1(object sender, RoutedEventArgs e)
        {           
            checkInRepo.CheckOut(controller.CurrentPerson);
            EmployeeCheckoutWindow checkoutWindow = new EmployeeCheckoutWindow();
            checkoutWindow.Show();
            this.Close();
        }
    }
}
