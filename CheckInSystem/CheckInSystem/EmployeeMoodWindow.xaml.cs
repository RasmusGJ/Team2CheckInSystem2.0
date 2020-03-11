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
using CheckInSystem.Domain_Layer;

namespace CheckInSystem
{
    /// <summary>
    /// Interaction logic for MoodWindow.xaml
    /// </summary>
    public partial class EmployeeMoodWindow : Window
    {
        Controller controller;

        public EmployeeMoodWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;                  
            
        }
        // Gets the controller from the previous window, so as to uphold the same data.
        public void GetController(Controller newController)
        {
            controller = new Controller()
            {
                CurrentPerson = newController.CurrentPerson
            };
            HideOrShowCheckOutBtn();          
        }
        // Hides or shows the checkout button based on whether or not the employee is logged in
        // If the employee is logged in, the button is shown, if not it will be hidden
        public void HideOrShowCheckOutBtn()
        {
            if (controller.CheckInRepo.CheckIfCheckedIn(controller.CurrentPerson as Employee) == true)
            {
                checkOutButton.Visibility = Visibility.Visible;
                moodLabel.Content = "\t\tDu er allerede checket ind.\nDu kan nu vælge at opdatere dit humør eller checke ud igen.";
            }
            else
            {
                checkOutButton.Visibility = Visibility.Hidden;
            }
            nameLabel.Content = controller.CurrentPerson.Name;
        }
        // Assigns the chosen mood to the selected employee logging in
        private void SadSelect(object sender, RoutedEventArgs e)
        {
            controller.AssignMood(Mood.Negative);
            OpenWelcomeWindow();

        }
        // Assigns the chosen mood to the selected employee logging in
        private void NeutralSelect(object sender, RoutedEventArgs e)
        {
            controller.AssignMood(Mood.Neutral);
            OpenWelcomeWindow();

        }
        // Assigns the chosen mood to the selected employee logging in
        private void HappySelect(object sender, RoutedEventArgs e)
        {
            controller.AssignMood(Mood.Positive);
            OpenWelcomeWindow();
        }
        // Goes to EmployeeWelcomeWindow
        private void OpenWelcomeWindow()
        {
            EmployeeWelcomeWindow employeeWelcomeWindow = new EmployeeWelcomeWindow();
            employeeWelcomeWindow.GetController(controller);
            employeeWelcomeWindow.Show();
            Thread.Sleep(10);
            this.Close();
        }
        // Checks out the employee from the database, and goes to the EmployeeCheckoutWindow
        private void CheckOutButton(object sender, RoutedEventArgs e)
        {           
            controller.CheckInRepo.CheckOut(controller.CurrentPerson);
            EmployeeCheckoutWindow employeeCheckoutWindow = new EmployeeCheckoutWindow();
            employeeCheckoutWindow.GetController(controller);
            employeeCheckoutWindow.Show();
            Thread.Sleep(10);
            this.Close();
        }
        // Returns to the EmployeePinCodeWindow
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeePinCodeWindow employeePinCodeWindow = new EmployeePinCodeWindow();
            employeePinCodeWindow.GetController(controller);
            employeePinCodeWindow.Show();
            Thread.Sleep(10);
            this.Close();
        }

    }
}
