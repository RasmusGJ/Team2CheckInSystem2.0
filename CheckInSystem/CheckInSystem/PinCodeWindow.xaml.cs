using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for PinCodeWindow.xaml
    /// </summary>
    public partial class PinCodeWindow : Window
    {
        public string pinCode;

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

            //The password has been entered.
            //Verify it here
            Controller controller = new Controller();
            controller.VerifyPin(pinCode);

            //Then:
            MoodWindow moodWindow = new MoodWindow();
            moodWindow.Show();
            this.Close();
            
        }
    }
}
