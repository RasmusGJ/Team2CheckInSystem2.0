using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for PinCodeWindow.xaml
    /// </summary>
    public partial class EmployeePinCodeWindow : Window
    {
        public Controller controller = new Controller();
        public EmployeePinCodeWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
        }
        // Gets the controller from the previous window, so the same data is uphold
        public void GetController(Controller newController)
        {
            controller = newController;
        }
        // Adds a number to the pincode as long as the pincode doesn't pass 4 numbers
        private void AddNum(object sender, RoutedEventArgs e)
        {
            if(TextBoxNumPad.Text.Length < 4)
            {
                TextBoxNumPad.Text += (sender as Button).Content;
            }
            UpdateCircles();
        }        
        // Updates the interface to fill out the circles as the pincode is filled out
        // So if the pincode has one number the first circle is filled and so on
        public void UpdateCircles()
        {
            switch (TextBoxNumPad.Text.Length)
            {
                case 0:
                    Ellipse1.Style = (Style)FindResource("EmptyEllipse");
                    Ellipse2.Style = (Style)FindResource("EmptyEllipse");
                    Ellipse3.Style = (Style)FindResource("EmptyEllipse");
                    Ellipse4.Style = (Style)FindResource("EmptyEllipse");
                    break;
                case 1:
                    Ellipse1.Style = (Style)FindResource("FilledEllipse");
                    Ellipse2.Style = (Style)FindResource("EmptyEllipse");
                    Ellipse3.Style = (Style)FindResource("EmptyEllipse");
                    Ellipse4.Style = (Style)FindResource("EmptyEllipse");
                    break;

                case 2:
                    Ellipse1.Style = (Style)FindResource("FilledEllipse");
                    Ellipse2.Style = (Style)FindResource("FilledEllipse");
                    Ellipse3.Style = (Style)FindResource("EmptyEllipse");
                    Ellipse4.Style = (Style)FindResource("EmptyEllipse");
                    break;

                case 3:
                    Ellipse1.Style = (Style)FindResource("FilledEllipse");
                    Ellipse2.Style = (Style)FindResource("FilledEllipse");
                    Ellipse3.Style = (Style)FindResource("FilledEllipse");
                    Ellipse4.Style = (Style)FindResource("EmptyEllipse");
                    break;

                case 4:
                    Ellipse1.Style = (Style)FindResource("FilledEllipse");
                    Ellipse2.Style = (Style)FindResource("FilledEllipse");
                    Ellipse3.Style = (Style)FindResource("FilledEllipse");
                    Ellipse4.Style = (Style)FindResource("FilledEllipse");                 
                    break;
                    
            }
        }
        // Removes the last entered number in the pincode 
        private void DeleteNum(object sender, RoutedEventArgs e)
        {
            if(TextBoxNumPad.Text.Length >= 1)
            {
                TextBoxNumPad.Text = TextBoxNumPad.Text.Remove(TextBoxNumPad.Text.Length - 1);
            }
            UpdateCircles();
        }
        // Starts the verification proccess for the pincode, only if there are 4 numbers in the string
        private void ClickVerify(object sender, RoutedEventArgs e)
        {
            if(TextBoxNumPad.Text.Length != 4)
            {
                MessageBox.Show("Pin too short, try again.");
                return;
            }

            //Calls method VerifyPin, which returns true or false. 
            //If it returns true, continues program. If false, displays error message
            
            string pinCode = TextBoxNumPad.Text;

            if (controller.VerifyPin(pinCode) == true)
            {
                EmployeeMoodWindow moodWindow = new EmployeeMoodWindow();
                moodWindow.GetController(controller);
                moodWindow.Show();
                Thread.Sleep(10);
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong pin code, try again.");
                TextBoxNumPad.Text = "";
                UpdateCircles();
            }
        }
        // Goes to the previous window MainWindow
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();            
            mainwindow.Show();
            Thread.Sleep(10);
            this.Close();
        }
    }
}
