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
        public PinCodeWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
        }

        private void AddNum(object sender, RoutedEventArgs e)
        {
            TextBoxNumPad.Text += (sender as Button).Content;

            UpdateCircles();

        }

        public void UpdateCircles()
        {
            switch (TextBoxNumPad.Text.Length)
            {
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

                    //The password has been entered.
                    //Verify it here
                    //Then:
                    MoodWindow moodWindow = new MoodWindow();
                    moodWindow.Show();
                    this.Close();
                    break;
            }

        }

        private void DeleteNum(object sender, RoutedEventArgs e)
        {
            TextBoxNumPad.Text = TextBoxNumPad.Text.Remove(TextBoxNumPad.Text.Length - 1);
            UpdateCircles();
        }
    }
}
