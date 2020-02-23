using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using CheckInSystem.Domain_Layer;
using System.Windows;

namespace CheckInSystem.Application_Layer
{
    public class CheckInRepo
    {
        List<CheckIn> checkIns = new List<CheckIn>();
        string ConnectionString = "Server=10.56.8.32;Database=A_GRUPEDB02_2019;User Id=A_GRUPE02;Password=A_OPENDB02";

        public CheckInRepo()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                DateTime today = DateTime.Now;
                string todayDate = today.ToString("yyyy-dd-MM");
                //Selects all from Employee tabel in database
                string stringQuery = "SELECT Id, FromDateTime, ToDateTime, Employee_Id, Guest_Id, Mood_Id " +
                    "FROM CheckIn " + 
                    "WHERE FromDateTime > '" + todayDate + "'";

                SqlCommand command = new SqlCommand(stringQuery, conn);
                conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CheckIn checkIn = new CheckIn();

                        //Adds relavent column to properties in Employee object. Then adds an employee to employees list.
                        checkIn.Id = reader.GetInt32("Id");
                        checkIn.FromTime = reader.GetDateTime("FromDateTime");
                        checkIn.ToTime = reader.GetDateTime("ToDateTime");
                        checkIn.mood = (Mood)(reader.GetInt32("Mood_Id"));

                        if (reader.GetInt32("Employee_Id") == 0)
                        {
                            //Guest guest = new Guest(); HUSK AT LAVE GUEST KLASSE!!!
                            //checkIn.person.Id = reader.GetString("Guest_Id");
                        }
                        else
                        {
                            Employee employee = new Employee();
                            employee.Id = reader.GetInt32("Employee_Id");
                            checkIn.person = employee;
                        }

                        checkIns.Add(checkIn);
                    }
                }
            }
        }

        public bool CheckIfCheckedIn(Employee person)
        {
            foreach(CheckIn checkIn in checkIns)
            {
                if(checkIn.ToTime.ToString("yyyy-dd-MM HH:mm:ss") == "1900-01-01 00:00:00" && checkIn.person.Id == person.Id)
                {
                    return true;
                }
            }

            return false;
        }

        public void CheckIn(CheckIn checkIn) 
        {
            checkIn.FromTime = DateTime.Now;
            string currentTime = checkIn.FromTime.ToString("yyyy-dd-MM HH:mm:ss");

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                //Insert a checkout time to database.

                string addCheckIn = checkIn.person is Employee ? //Test if the person is an employee
                    "INSERT INTO CheckIn ( FromDateTime, Employee_Id , Mood_Id) " +                         //If person is an employee(true)
                    "VALUES ('" + currentTime + "'," + checkIn.person.Id + "," + (int)checkIn.mood + ");"    // 
                    : 
                    "INSERT INTO CheckIn ( FromDateTime, Guest_Id) " +                                      //If person is not an employee(false)
                    "VALUES ('" + currentTime + "'," + checkIn.person.Id + ");";                             //

                MessageBox.Show(addCheckIn);

                using (SqlCommand command = new SqlCommand(addCheckIn, conn))
                {
                    conn.Open();
                    int result = command.ExecuteNonQuery();

                    if(result < 0)
                    {
                        MessageBox.Show("Error: no lines have been added");
                    }
                }
            }
        }

        public void CheckOut(Person person)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                //Insert a checkout time to database.
                string addCheckOutTimeEmployee = "INSERT INTO CheckIn ( ToDateTime ) " +
                    "VALUES (" + DateTime.Now + ") WHERE " + person.Id + "= Employee_Id;";
                string addCheckOutTimeGuest = "INSERT INTO CheckIn ( ToDateTime ) " +
                    "VALUES (" + DateTime.Now + ") WHERE " + person.Id + "= Guest_Id;";

                SqlCommand command = new SqlCommand(addCheckOutTimeEmployee + addCheckOutTimeGuest, conn);
                conn.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {

                }
            }
        }
    }
}
