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
        public List<Appointment> appointments = new List<Appointment>();
        public Appointment currentAppointment = new Appointment();

        public AppointmentRepo()
        {            
            string ConnectionString = "Server=10.56.8.32;Database=A_GRUPEDB02_2019;User Id=A_GRUPE02;Password=A_OPENDB02";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                //Selects all from Employee tabel in database
                string pinCodeQuery = "SELECT Appointment.Id, Appointment.FromDateTime, Appointment.ToDateTime,Appointment.Employee_Id AS Booker, AppointmentToEmployee.Employee_Id, AppointmentToGuest.Guest_Id FROM Appointment " +
                                        "LEFT JOIN AppointmentToEmployee ON Appointment.Id = AppointmentToEmployee.Appointment_Id " +
                                        "INNER JOIN AppointmentToGuest ON Appointment.Id = AppointmentToGuest.Appointment_Id " +
                                        "WHERE FromDateTime >= '" + DateTime.Now.Date.ToString("yyyy-dd-MM") + "' OR ToDateTime >= '" + DateTime.Now.Date.ToString("yyyy-dd-MM") + "';";

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
                        appointment.Booker = new Employee() { Id = reader.GetInt32(3) };
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
                foreach (Guest g in ap.Guests)
                {
                    if (g.Id == id)
                    {
                        if(ap.FromTime.Date == DateTime.Now)
                        {
                            currentAppointment = ap;
                            return true;

                        }
                    }
                }               
            }
            return false;
        }

        public void GetBookerInfo()
        {
            int bookerId = currentAppointment.Booker.Id;
            string ConnectionString = "Server=10.56.8.32;Database=A_GRUPEDB02_2019;User Id=A_GRUPE02;Password=A_OPENDB02";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                //Selects all from Employee tabel in database
                string employeeAppointmentQuery = "SELECT Employee.Id, Employee.Name, Role.Title AS RoleTitle, Department.Title AS DepartmentTitle " +
                    "FROM Employee " +
                    "INNER JOIN Role ON Employee.Role_Id = Role.Id " +
                    "INNER JOIN Department ON Role.Department_Id = Department.Id " +
                    "WHERE Employee.Id = " + bookerId + ";";

                SqlCommand command = new SqlCommand(employeeAppointmentQuery, conn);
                conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        currentAppointment.Booker.Name = reader.GetString(1);
                        currentAppointment.Booker.Role = reader.GetString(2);
                        currentAppointment.Booker.Department = reader.GetString(3);
                    }
                }
            }
        }
    }
}
