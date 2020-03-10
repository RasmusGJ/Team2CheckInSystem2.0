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
                //Selects all from relevant appointments including guest and employee id's
                string pinCodeQuery = "SELECT Appointment.Id, Appointment.FromDateTime, Appointment.ToDateTime,Appointment.Employee_Id AS Booker, AppointmentToEmployee.Employee_Id, AppointmentToGuest.Guest_Id FROM Appointment " +
                                        "LEFT JOIN AppointmentToEmployee ON Appointment.Id = AppointmentToEmployee.Appointment_Id " +
                                        "INNER JOIN AppointmentToGuest ON Appointment.Id = AppointmentToGuest.Appointment_Id " +
                                        "WHERE FromDateTime >= '" + DateTime.Now.Date.ToString("yyyy-dd-MM") + "' OR ToDateTime >= '" + DateTime.Now.Date.ToString("yyyy-dd-MM") + "' ORDER BY FromDateTime ASC;";

                SqlCommand command = new SqlCommand(pinCodeQuery, conn);
                conn.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //Foreach row selected from the database, create an appointment
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

        //Method to check if the a guest has a relevant appoint that needs to be shown
        public bool CheckIfAppointment(int id)
        {
            foreach(Appointment ap in appointments)
            {
                foreach (Guest g in ap.Guests)
                {
                    if (g.Id == id)
                    {
                        //Selects only relevant appointment
                        if(ap.FromTime.Date <= DateTime.Now)
                        {
                            currentAppointment = ap;
                            return true;

                        }
                    }
                }               
            }
            return false;
        }

        //Method used to insert information about the employee that booked the appointment
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
                        //The book information is inserted into the appointment object
                        currentAppointment.Booker.Name = reader.GetString(1);
                        currentAppointment.Booker.Role = reader.GetString(2);
                        currentAppointment.Booker.Department = reader.GetString(3);
                    }
                }
            }
        }
    }
}
