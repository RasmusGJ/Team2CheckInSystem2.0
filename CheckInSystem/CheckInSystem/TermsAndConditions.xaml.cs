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

namespace CheckInSystem
{
    /// <summary>
    /// Interaction logic for FirePopup.xaml
    /// </summary>
    public partial class TermsAndConditions : Window
    {
        public TermsAndConditions()
        {
            InitializeComponent();
        }

        private void CloseTermsAndConditions_Click(object sender, RoutedEventArgs e)
        {
            AnnounceArrivalWindow announceArrivalWindow = new AnnounceArrivalWindow();
            this.Close();
        }
    }
}
