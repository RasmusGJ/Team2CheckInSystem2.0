using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using CheckInSystem.Domain_Layer;

namespace CheckInSystem.Application_Layer
{
    public class CheckInRepo
    {
        public TimeStamp stamp;
        public List<CheckIn> CheckIns = new List<CheckIn>();
        public bool CheckIfCheckedIn(Person person)
        {

            return true;
        }

        public void CheckIn(CheckIn checkIn) 
        {
            checkIn.FromTime = DateTime.Now;
            CheckIns.Add(checkIn);
        }

        public void CheckOut(Person person)
        {
            string ConnectionString = "Server=10.56.8.32;Database=A_GRUPEDB02_2019;User Id=A_GRUPE02;Password=A_OPENDB02";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                //Insert a checkout time to database.
                string addCheckOutTimeEmployee = "INSERT INTO CheckIn ( ToDateTime ) " +
                    "VALUES (" + stamp.ToTime + ") WHERE " + person.Id + "= Employee_Id;";
                string addCheckOutTimeGuest = "INSERT INTO CheckIn ( ToDateTime ) " +
                    "VALUES (" + stamp.ToTime + ") WHERE " + person.Id + "= Guest_Id;";

                SqlCommand command = new SqlCommand(addCheckOutTimeEmployee + addCheckOutTimeGuest, conn);
                conn.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {

                }
            }
        }
    }
}
