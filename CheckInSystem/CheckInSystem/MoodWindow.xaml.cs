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
        Controller controller;

        public MoodWindow()
        {

            InitializeComponent();
            WindowState = WindowState.Maximized;
                  
            
        }

        public void GetController(Controller newController)
        {
            controller = newController;
            MessageBox.Show(newController.CurrentPerson.Name);

            HideOrShowCheckOutBtn();
            

        }

        public void HideOrShowCheckOutBtn()
        {
            if (controller.CheckInRepo.CheckIfCheckedIn(controller.CurrentPerson as Employee) == true)
            {
                checkOutButton.Visibility = Visibility.Visible;
            }
            else
            {
                checkOutButton.Visibility = Visibility.Hidden;
            }


            nameLabel.Content = controller.CurrentPerson.Name;
        }

        private void SadSelect(object sender, RoutedEventArgs e)
        {
            controller.AssignMood(Mood.Negative);
            OpenWelcomeWindow();

        }

        private void NeutralSelect(object sender, RoutedEventArgs e)
        {
            controller.AssignMood(Mood.Neutral);
            OpenWelcomeWindow();

        }

        private void HappySelect(object sender, RoutedEventArgs e)
        {
            controller.AssignMood(Mood.Positive);
            OpenWelcomeWindow();
        }

        private void OpenWelcomeWindow()
        {
            EmployeeWelcomeWindow welcomeWindow = new EmployeeWelcomeWindow();
            welcomeWindow.GetController(controller);
            welcomeWindow.Show();
            this.Close();

        }


        private void checkOutButton_Click_1(object sender, RoutedEventArgs e)
        {           
            controller.CheckInRepo.CheckOut(controller.CurrentPerson);
            EmployeeCheckoutWindow checkoutWindow = new EmployeeCheckoutWindow();
            checkoutWindow.GetController(controller);
            checkoutWindow.Show();
            this.Close();
        }
    }
}
