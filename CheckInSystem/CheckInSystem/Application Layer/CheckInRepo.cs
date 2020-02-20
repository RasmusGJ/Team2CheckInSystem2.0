using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace CheckInSystem.Application_Layer
{
    public class CheckInRepo
    {
        public List<CheckIn> CheckIns = new List<CheckIn>();
        private bool CheckIfCheckedIn(Person person)
        {
            return true;
        }

        public void CheckIn(CheckIn checkIn) 
        { 

        }

        public void CheckOut(Person person)
        {
            
            string ConnectionString = "Server=10.56.8.32;Database=A_GRUPEDB02_2019;User Id=A_GRUPE02;Password=A_OPENDB02";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                //Insert a checkout time to database.
                string addCheckOutTime = "";

                SqlCommand command = new SqlCommand(addCheckOutTime, conn);
                conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                       
                    }
                }
            }
        }
    }
}
