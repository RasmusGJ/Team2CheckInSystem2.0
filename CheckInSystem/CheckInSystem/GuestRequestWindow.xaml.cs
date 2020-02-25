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
    /// Interaction logic for GuestRequestWindow.xaml
    /// </summary>
    public partial class GuestRequestWindow : Window
    {
        public GuestRequestWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            EmployeeRepo employeeRepo = new EmployeeRepo();
            DataContext = employeeRepo;
        }
    }
}
