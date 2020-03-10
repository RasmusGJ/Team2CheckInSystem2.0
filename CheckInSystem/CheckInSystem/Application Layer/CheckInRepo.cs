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
        List<CheckIn> checkIns = new List<CheckIn>(); //List for containing checkIns

        string ConnectionString = "Server=10.56.8.32;Database=A_GRUPEDB02_2019;User Id=A_GRUPE02;Password=A_OPENDB02"; //Connection strings for sql queries

        public CheckInRepo()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                DateTime today = DateTime.Now;
                string todayDate = today.ToString("yyyy-dd-MM");
                //Selects all from CheckIn table in database
                string stringQuery = "SELECT Id, FromDateTime, ToDateTime, Employee_Id, Guest_Id, Mood_Id " +
                    "FROM CheckIn " + 
                    "WHERE FromDateTime > '" + todayDate + "' " +
                    "ORDER BY FromDateTime DESC";

                SqlCommand command = new SqlCommand(stringQuery, conn);
                conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CheckIn checkIn = new CheckIn();

                        //Adds relavent column to properties in the checkIn object. Then adds a CheckIn to checkIns list.
                        checkIn.Id = reader.GetInt32("Id");
                        checkIn.FromTime = reader.GetDateTime("FromDateTime");
                        checkIn.ToTime = reader.GetDateTime("ToDateTime");
                        checkIn.mood = (Mood)(reader.GetInt32("Mood_Id"));

                        //Here we want to insert a person into the checkIn object
                        //We start by trying to get an employee id, if this fails we know the column in the database was null
                        try
                        {
                            int id = reader.GetInt32("Employee_Id");
                            Employee employee = new Employee();
                            employee.Id = id;
                            checkIn.person = employee;
                        }
                        catch //If the try fails we know it's a guest check in
                        {
                            Guest guest = new Guest();
                            guest.Id = reader.GetInt32("Guest_Id");
                            checkIn.person = guest;
                        }                      
                        //Add checkIn object to list
                        checkIns.Add(checkIn);
                    }
                }
            }
        }


        //Checks if an employee is logged in
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

        //Insert check in object to database
        public void CheckIn(CheckIn checkIn) 
        {
            checkIn.FromTime = DateTime.Now;
            string currentTime = checkIn.FromTime.ToString("yyyy-dd-MM HH:mm:ss");

            //Check if the checkIn is caused by an employee changing their mood
            if(checkIn.person is Employee)
            {
                Person checkInPerson = new Employee();
                checkInPerson.Id = checkIn.person.Id;

                if (CheckIfCheckedIn(checkInPerson as Employee) == true)
                {
                    CheckOut(checkInPerson);
                }
            }

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                //Insert a checkIn time to database.
                string addCheckIn = checkIn.person is Employee ? //Test if the person is an employee (using Elvis operator)
                    "INSERT INTO CheckIn ( FromDateTime, Employee_Id , Mood_Id) " +                         //If person is an employee(true)
                    "VALUES ('" + currentTime + "'," + checkIn.person.Id + "," + (int)checkIn.mood + ");"    // 
                    : 
                    "INSERT INTO CheckIn ( FromDateTime, Guest_Id) " +                                      //If person is not an employee(false)
                    "VALUES ('" + currentTime + "'," + checkIn.person.Id + ");";                             //

                //Execute query
                using (SqlCommand command = new SqlCommand(addCheckIn, conn))
                {
                    conn.Open();
                    int result = command.ExecuteNonQuery();

                    //Test if an error occurecd. Result = number lines changed
                    if(result < 0)
                    {
                        MessageBox.Show("Error: no lines have been added");
                    }
                }
            }
        }

        //Insert check out time to databse checkIn row
        public void CheckOut(Person person)
        {
            int Id = 0;
            foreach (CheckIn checkIn in checkIns)
            {
                //Check if the checkIn is already checked out and if the person connected to the checkIn object is the same as we receive in the 
                //parameters
                if (checkIn.ToTime.ToString("yyyy-dd-MM HH:mm:ss") == "1900-01-01 00:00:00" && checkIn.person.Id == person.Id)
                {
                    Id = checkIn.Id;
                }
            }

            //Get time of check out
            string currentTime = DateTime.Now.ToString("yyyy-dd-MM HH:mm:ss");

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                //Insert a checkout time to database.
                string checkOutQuery = "UPDATE CheckIn " +
                "SET ToDateTime = '" + currentTime + "' " + 
                "WHERE Id =" + Id + ";";

                //Execute query
                using (SqlCommand command = new SqlCommand(checkOutQuery, conn))
                {
                    conn.Open();
                    int result = command.ExecuteNonQuery();

                    //Test if an error occurecd. Result = number lines changed
                    if (result < 0)
                    {
                        MessageBox.Show("Error: no lines have been added");
                    }
                }


            }
        }
    }
}
