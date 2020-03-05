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
    public partial class PinCodeWindow : Window
    {
        public Controller controller = new Controller();
        public PinCodeWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
        }

        private void AddNum(object sender, RoutedEventArgs e)
        {
            if(TextBoxNumPad.Text.Length < 4)
            {
                TextBoxNumPad.Text += (sender as Button).Content;
            }

            UpdateCircles();

        }        

        public void GetController(Controller newcontroller)
        {
            controller = newcontroller;
        }

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
        private void DeleteNum(object sender, RoutedEventArgs e)
        {
            if(TextBoxNumPad.Text.Length >= 1)
            {
                TextBoxNumPad.Text = TextBoxNumPad.Text.Remove(TextBoxNumPad.Text.Length - 1);
            }
            
            UpdateCircles();
        }

        private void ClickVerify(object sender, RoutedEventArgs e)
        {
            if(TextBoxNumPad.Text.Length != 4)
            {
                MessageBox.Show("Incorrect pin");
                return;
            }

            //Calls method VerifyPin, which returns true or false. 
            //If it returns true, continues program. If false, displays error message
            
            string pinCode = TextBoxNumPad.Text;

            if (controller.VerifyPin(pinCode) == true)
            {
                MoodWindow moodWindow = new MoodWindow();
                moodWindow.GetController(controller);
                moodWindow.Show();
                Thread.Sleep(10);
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong PinCode BITCH");
                TextBoxNumPad.Text = "";
                UpdateCircles();
            }

        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();            
            mainwindow.Show();
            Thread.Sleep(10);
            this.Close();
        }
    }
}
