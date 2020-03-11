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
using System.Diagnostics;

namespace CheckInSystem
{
    /// <summary>
    /// Interaction logic for GuestRequestWindow.xaml
    /// </summary>
    public partial class GuestRequestPersonalWindow : Window
    {
        Controller controller;
        public GuestRequestPersonalWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            EmployeeRepo employeeRepo = new EmployeeRepo();
            DataContext = employeeRepo;            
            listView.ItemsSource = employeeRepo.employees;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listView.ItemsSource);
            view.Filter = UserFilter;
        }
        // Gets the controller from the previous window, so the same data is uphold
        public void GetController(Controller newController)
        {
            controller = newController;
        }
        // Filters the listview based on the input from the textboxes
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
        // Refreshes the Listview if there is text in the textboxes
        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(listView.ItemsSource).Refresh();
        }
        // Goes back to the previous window 
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            GuestNoMeetingWindow guestNoMeetingWindow = new GuestNoMeetingWindow();
            guestNoMeetingWindow.GetController(controller);
            guestNoMeetingWindow.Show();
            Thread.Sleep(10);
            this.Close();
        }
        // Checks if the required textboxes have been filled, if not a messagebox will pop up 
        private void Click_Ok(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(nameFilter.Text) || string.IsNullOrEmpty(departmentFilter.Text))
            {
                MessageBox.Show("Please fill out the 2 fields.");
            }
            else
            {
                controller.CurrentPersonName = nameFilter.Text;
                GuestNotificationSentWindow guestNotificationSentWindow = new GuestNotificationSentWindow();
                guestNotificationSentWindow.GetController(controller);
                guestNotificationSentWindow.Show();
                Thread.Sleep(10);
                this.Close();
            }
        }
        // Opens the on screen keyboard
        private void KeyBoard_Click(object sender, RoutedEventArgs e)
        {
            Process process = new Process();
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.WorkingDirectory = "c:\\";
            process.StartInfo.FileName = "c:\\WINDOWS\\system32\\osk.exe";
            process.StartInfo.Verb = "runas";
            process.Start();
        }
        // Clears the textboxes for text
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            nameFilter.Clear();
            departmentFilter.Clear();

            listView.SelectedItem = null;
        }
    }
}
