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
    public partial class GuestArrivalWindow : Window
    {
        Controller controller = new Controller();
        GuestRepo guestRepo;
        AppointmentRepo appointmentRepo;
        public GuestArrivalWindow()
        {
            
            InitializeComponent();
            WindowState = WindowState.Maximized;
        }

        public void GetController(Controller newController)
        {
            controller = newController;
            guestRepo = controller.guestRepo;
            appointmentRepo = controller.appointmentRepo;
            DataContext = guestRepo;
            listView.ItemsSource = guestRepo.guests;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listView.ItemsSource);
            view.Filter = UserFilter;
        }


        // Filters the listview so the listview matches the information in the textboxes
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

        // Refreshes the list view when there are changes made to their source
        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(listView.ItemsSource).Refresh();
        }

        // Goes to MainWindow
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            Thread.Sleep(10);
            this.Close();
        }
        
        // Goes to the next window
        private void Ok_Button(object sender, RoutedEventArgs e)
        {
            // If the text boxes are not filled, and the terms and conditions are not accepted, a messagebox will appear.
            if (string.IsNullOrEmpty(nameBox.Text) || string.IsNullOrEmpty(compBox.Text) || string.IsNullOrEmpty(phoneBox.Text) || string.IsNullOrEmpty(emailBox.Text) || termsBox.IsChecked  == false)
            {
                MessageBox.Show("Please fill out the 4 fields. \nPlease accept terms and conditions");
            }
            else
            {
                guestRepo.AddGuestToDB(idBox.Text, nameBox.Text, compBox.Text, emailBox.Text, phoneBox.Text);

                //Assigns a new checkin to the selectedguest
                CheckIn checkIn = new CheckIn() { person = guestRepo.SelectedGuest };
                controller.CheckInRepo.CheckIn(checkIn);
                int parsedId = 0;
                bool test = Int32.TryParse(idBox.Text, out parsedId);
                // Checks if the guest has an appointment in the database, and sends them to the relevant window.
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
                    GuestNoMeetingWindow noReservationWindow = new GuestNoMeetingWindow();
                    controller.CurrentPersonName = nameBox.Text;
                    noReservationWindow.GetController(controller);
                    noReservationWindow.Show();
                    Thread.Sleep(10);
                    this.Close();
                }                
            }
        }
        // Gives a hyperlink to the text, so the terms of service window opens, and can be read 
        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            TermsAndConditions termsAndConditions = new TermsAndConditions();
            termsAndConditions.Show();
        }
        // Opens up an on-screen keyboard for inputing text into the text boxes.
        private void KeyBoard_Click(object sender, RoutedEventArgs e)
        {
            Process process = new Process();
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.WorkingDirectory = "c:\\";
            process.StartInfo.FileName = "c:\\WINDOWS\\system32\\osk.exe";
            process.StartInfo.Verb = "runas";
            process.Start();
        }
        // A Clear option that makes it easier to clear the textboxes.
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            nameBox.Clear();
            compBox.Clear();
            phoneBox.Clear();
            emailBox.Clear();
        }

    }
}

