using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace WindowBuilder___Projekt
{
    public class EmployeeRepo
    {
        public List<Employee> employees = new List<Employee>();
        public EmployeeRepo()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Server=10.56.8.32;Database=A_GRUPEDB02_2019;User Id=A_GRUPE02;Password=A_OPENDB02";

                string pinCodeQuery = $"SELECT * FROM EMPLOYEE INNER JOIN Role.Title AS RoleTitle ON (";

                SqlCommand command = new SqlCommand(pinCodeQuery);
                conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Employee employee = new Employee();

                        employee.Name = reader.GetString("Name");
                        employee.IMG = reader.GetString("IMG");
                        employee.Initials = reader.GetString("Initials");
                        employee.LandLinePhone = reader.GetString("LandLinePhone");
                        employee.PinCode = reader.GetString("PinCode");
                    }

                }
            }
        }       

        public void AddEmployee()
        {

        }
        /*
        public void nothing()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Server=10.56.8.32;Database=A_GRUPEDB02_2019;User Id=A_GRUPE02;Password=A_OPENDB02";

                string pinCodeQuery = $"SELECT * FROM EMPLOYEE WHERE PinCode = {pinCode}";

                SqlCommand command = new SqlCommand(pinCodeQuery);
                conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Employee employee = new Employee();
                        employee.PinCode = reader.GetString("PinCode");

                    }

                }
            }
        }
        */
    }
}
