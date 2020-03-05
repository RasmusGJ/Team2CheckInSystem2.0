using System;
using System.Collections.Generic;
using System.Text;
using CheckInSystem.Domain_Layer;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace CheckInSystem.Application_Layer
{
    public class AppointmentRepo
    {
        List<Appointment> appointments = new List<Appointment>();

        public AppointmentRepo()
        {
            
            string ConnectionString = "Server=10.56.8.32;Database=A_GRUPEDB02_2019;User Id=A_GRUPE02;Password=A_OPENDB02";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                //Selects all from Employee tabel in database
                string pinCodeQuery = "SELECT Appointment.Id, Appointment.FromDateTime, Appointment.ToDateTime,Appointment.Employee_Id AS Booker , AppointmentToEmployee.Employee_Id, AppointmentToGuest.Guest_Id FROM Appointment " +
                                        "LEFT JOIN AppointmentToEmployee ON Appointment.Id = AppointmentToEmployee.Appointment_Id " +
                                        "INNER JOIN AppointmentToGuest ON Appointment.Id = AppointmentToGuest.Appointment_Id " +
                                        "WHERE FromDateTime >= '" + DateTime.Now.Date.ToString("yyyy-dd-MM") + "'; ";

                SqlCommand command = new SqlCommand(pinCodeQuery, conn);
                conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Appointment appointment = new Appointment();
                        appointment.Id = reader.GetInt32(0);
                        appointment.FromTime = reader.GetDateTime(1);
                        appointment.ToTime = reader.GetDateTime(2);
                        appointment.Guests.Add(new Guest() { Id = reader.GetInt32(5) });


                        appointments.Add(appointment);
                    }
                }
            }
        }
        public bool CheckIfAppointment(int id)
        {
            foreach(Appointment ap in appointments)
            {
                if (ap.Id == id)
                {                    
                    return true;
                }
            }
            return false;
        }
    }
}
