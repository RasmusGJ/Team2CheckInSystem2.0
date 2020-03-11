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
        //The SelectedGuest property is used in the windows that wish to -
        //grab a selected guest from lists.  
        private Guest selectedGuest;
        public ObservableCollection<Guest> observableCollectionGuest { get; set; } = new ObservableCollection<Guest>();
        public Guest SelectedGuest { get { return selectedGuest; } set { selectedGuest = value; OnPropertyChanged("SelectedProduct"); } }

        //Uses constructor to populate the List employees- 
        //when EmployeeRepo object is created
        public List<Guest> guests { get; set; } = new List<Guest>();
        public GuestRepo()
        {
            string ConnectionString = "Server=10.56.8.32;Database=A_GRUPEDB02_2019;User Id=A_GRUPE02;Password=A_OPENDB02";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                //Selects all from Guest tabel in database
                string guestQuery = "SELECT Guest.Name, Guest.Email, Guest.Company, Guest.MobilePhone, Guest.Id " +
                    "FROM Guest;";

                SqlCommand command = new SqlCommand(guestQuery, conn);
                conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Guest guest = new Guest();
                        //Adds relavent column to properties in Guest object. Then adds a guest to guests list.
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
        
        //The AddGuestToDB method adds data passed through-
        //the methods parameter to the guest tabel in the database.
        //The method checks if id passed through parameter is equivilent-
        //to any guest id's in database -> if so, then UPDATE guest information.
        public void AddGuestToDB(string id, string name, string company, string email, string phone)
        {
            if (string.IsNullOrEmpty(id))
            {
                id = "0";
            }
            int parsedId = Int32.Parse(id);
            string ConnectionString = "Server=10.56.8.32;Database=A_GRUPEDB02_2019;User Id=A_GRUPE02;Password=A_OPENDB02";

            //
            //
            foreach (Guest g in guests)
            {
                if (g.Id == parsedId)
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString))
                    {
                        string guestInsertQuery = "UPDATE Guest SET Name = '" + name + "', Email = '" + email + "', Company = '" + company + "', MobilePhone = '" + phone + "' WHERE Guest.Id = " + id + ";";

                        SqlCommand command = new SqlCommand(guestInsertQuery, conn);
                        conn.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                        }
                    }
                    SelectedGuest = g;
                    return;
                }                
            }

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                Guest g = new Guest();
                string guestInsertQuery = "INSERT INTO Guest (Name, Email, Company, MobilePhone) VALUES ('" + name + "', '" + email + "', '" + company + "', '" + phone + "');";
                string guestIdQuery = "SELECT MAX (Id) FROM Guest;";

                SqlCommand command = new SqlCommand(guestInsertQuery + guestIdQuery, conn);
                conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                   
                    while (reader.Read())
                    {
                        g.Id = reader.GetInt32(0);
                        SelectedGuest = g;
                    }
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
