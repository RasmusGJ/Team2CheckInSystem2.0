using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using CheckInSystem.Domain_Layer;
using System.Windows;

namespace CheckInSystem.Application_Layer
{
    public class CheckInRepo
    {
        string ConnectionString = "Server=10.56.8.32;Database=A_GRUPEDB02_2019;User Id=A_GRUPE02;Password=A_OPENDB02";

        public bool CheckIfCheckedIn(Person person)
        {

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {

                string checkForCheckIn = person is Employee ? //Test if the person is an employee
                    "INSERT INTO CheckIn ( FromDateTime, Employee_Id , Mood_Id) " +                         //If person is an employee(true)
                    "VALUES ();"    // 
                    :
                    "INSERT INTO CheckIn ( FromDateTime, Guest_Id) " +                                      //If person is not an employee(false)
                    "VALUES ();";                             //

                SqlCommand command = new SqlCommand(checkForCheckIn, conn);
                conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    
                }
                return true;
            }
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
