using System;
using System.Collections.Generic;
using System.Text;
using CheckInSystem.Domain_Layer;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Collections.ObjectModel;


namespace CheckInSystem.Application_Layer
{
    public class GuestRepo : INotifyPropertyChanged
    {
        private Guest selectedGuest;
        public ObservableCollection<Guest> observableCollectionGuest { get; set; } = new ObservableCollection<Guest>();
        public Guest SelectedGuest { get { return selectedGuest; } set { selectedGuest = value; OnPropertyChanged("SelectedProduct"); } }
        

        public List<Guest> guests { get; set; } = new List<Guest>();
        public GuestRepo()
        {
            string ConnectionString = "Server=10.56.8.32;Database=A_GRUPEDB02_2019;User Id=A_GRUPE02;Password=A_OPENDB02";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                //Selects all from Employee tabel in database
                string guestQuery = "SELECT Guest.Name, Guest.Email, Guest.Company, Guest.MobilePhone, Guest.Id " +
                    "FROM Guest;";

                SqlCommand command = new SqlCommand(guestQuery, conn);
                conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Guest guest = new Guest();
                        //Adds relavent column to properties in Guest object. Then adds an employee to employees list.
                        guest.Name = reader.GetString(0);
                        guest.Email = reader.GetString(1);
                        guest.Company = reader.GetString(2);
                        guest.MobilePhone = reader.GetString(3);
                        guest.Id = reader.GetInt32(4);
                        guests.Add(guest);
                    }
                }
            }            
        }

        public void AddGuestToDB(string name, string company, string email, string phone)
        {
            string ConnectionString = "Server=10.56.8.32;Database=A_GRUPEDB02_2019;User Id=A_GRUPE02;Password=A_OPENDB02";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                //Selects all from Employee tabel in database
                string guestInsertQuery = "IF NOT EXISTS (SELECT * FROM Guest WHERE Guest.MobilePhone = '" + phone + "') INSERT INTO Guest VALUES ('" + name + "', '" + email + "', '" + company + "', '" + phone + "');";

                SqlCommand command = new SqlCommand(guestInsertQuery, conn);
                conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {

                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
