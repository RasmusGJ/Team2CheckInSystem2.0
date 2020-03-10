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
using System.Threading;
using System.Diagnostics;

namespace CheckInSystem
{
    /// <summary>
    /// Interaction logic for AnnounceArrivalWindow.xaml
    /// </summary>
    public partial class AnnounceArrivalWindow : Window
    {
        Controller controller = new Controller();
        GuestRepo guestRepo;
        AppointmentRepo appointmentRepo;
        public AnnounceArrivalWindow()
        {
            
            InitializeComponent();
            WindowState = WindowState.Maximized;
            guestRepo = controller.guestRepo;
            appointmentRepo = controller.appointmentRepo;
            DataContext = guestRepo;
            listView.ItemsSource = guestRepo.guests;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listView.ItemsSource);
            view.Filter = UserFilter;
        }
        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(nameBox.Text) && String.IsNullOrEmpty(compBox.Text))
                return true;

            else if (String.IsNullOrEmpty(compBox.Text) == false && String.IsNullOrEmpty(nameBox.Text))
                return ((item as Guest).Company.IndexOf(compBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);

            else if (String.IsNullOrEmpty(nameBox.Text) == false && String.IsNullOrEmpty(compBox.Text))
                return ((item as Guest).Name.IndexOf(nameBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);

            else
                return ((item as Guest).Name.IndexOf(nameBox.Text, StringComparison.OrdinalIgnoreCase) >= 0 &&
                    (item as Guest).Company.IndexOf(compBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(listView.ItemsSource).Refresh();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            Thread.Sleep(10);
            this.Close();
        }
      
        private void Ok_Button(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(nameBox.Text) || string.IsNullOrEmpty(compBox.Text) || string.IsNullOrEmpty(phoneBox.Text) || string.IsNullOrEmpty(emailBox.Text) || termsBox.IsChecked  == false)
            {
                MessageBox.Show("Please fill out the 4 fields. \nPlease accept terms and conditions");
            }
            else
            {
                guestRepo.GuestDB(idBox.Text, nameBox.Text, compBox.Text, emailBox.Text, phoneBox.Text);

                CheckIn checkIn = new CheckIn() { person = guestRepo.SelectedGuest };
                controller.CheckInRepo.CheckIn(checkIn);
                int parsedId = 0;
                bool test = Int32.TryParse(idBox.Text, out parsedId);
                if (appointmentRepo.CheckIfAppointment(parsedId) == true)
                {
                    GuestMeetingWindow meetingGuestWindow = new GuestMeetingWindow();
                    controller.CurrentPersonName = nameBox.Text;
                    meetingGuestWindow.GetController(controller);
                    meetingGuestWindow.Show();
                    Thread.Sleep(10);
                    this.Close();
                }
                else
                {
                    NoReservationWindow noReservationWindow = new NoReservationWindow();
                    controller.CurrentPersonName = nameBox.Text;
                    noReservationWindow.GetController(controller);
                    noReservationWindow.Show();
                    Thread.Sleep(10);
                    this.Close();
                }                
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            TermsAndConditions termsAndConditions = new TermsAndConditions();
            termsAndConditions.Show();
        }
        private void KeyBoard_Click(object sender, RoutedEventArgs e)
        {
            Process process = new Process();
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.WorkingDirectory = "c:\\";
            process.StartInfo.FileName = "c:\\WINDOWS\\system32\\osk.exe";
            process.StartInfo.Verb = "runas";
            process.Start();
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            nameBox.Clear();
            compBox.Clear();
            phoneBox.Clear();
            emailBox.Clear();
        }

    }
}

