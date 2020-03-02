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
            listView.ItemsSource = employeeRepo.employees;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listView.ItemsSource);
            view.Filter = UserFilter;
        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(nameFilter.Text) && String.IsNullOrEmpty(departmentFilter.Text))
                return true;        
            
            else if (String.IsNullOrEmpty(departmentFilter.Text) == false && String.IsNullOrEmpty(nameFilter.Text))
                return ((item as Employee).Department.IndexOf(departmentFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);

            else if(String.IsNullOrEmpty(nameFilter.Text) == false && String.IsNullOrEmpty(departmentFilter.Text))
                return ((item as Employee).Name.IndexOf(nameFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);

            else
                return ((item as Employee).Name.IndexOf(nameFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0 && 
                    (item as Employee).Department.IndexOf(departmentFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(listView.ItemsSource).Refresh();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
