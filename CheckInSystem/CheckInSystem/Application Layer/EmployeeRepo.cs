using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using CheckInSystem.Domain_Layer;

namespace CheckInSystem.Application_Layer
{
    public class EmployeeRepo
    {
        public List<Employee> employees { get; set; } = new List<Employee>();
        public EmployeeRepo()
        {
            string ConnectionString = "Server=10.56.8.32;Database=A_GRUPEDB02_2019;User Id=A_GRUPE02;Password=A_OPENDB02"; 

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                //Selects all from Employee tabel in database
                string pinCodeQuery = "SELECT Employee.Id, Employee.Name, Employee.Email, Employee.MobilePhone, Employee.LandlinePhone, Employee.Initials, Employee.PinCode, Role.Title AS RoleTitle, Department.Title AS DepartmentTitle " +
                    "FROM Employee " +
                    "INNER JOIN Role ON Employee.Role_Id = Role.Id " +
                    "INNER JOIN Department ON Role.Department_Id = Department.Id";

                SqlCommand command = new SqlCommand(pinCodeQuery, conn);
                conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Employee employee = new Employee();

                        //Adds relavent column to properties in Employee object. Then adds an employee to employees list.
                        employee.Name = reader.GetString("Name");
                        employee.Initials = reader.GetString("Initials");
                        employee.LandlinePhone = reader.GetString("LandlinePhone");
                        employee.PinCode = reader.GetString("PinCode");
                        employee.Email = reader.GetString("Email");
                        employee.Role = reader.GetString("RoleTitle");
                        employee.MobilePhone = reader.GetString("MobilePhone");
                        employee.Department = reader.GetString("DepartmentTitle");
                        employee.Id = reader.GetInt32("Id");
                        employees.Add(employee);
                    }
                }
            }
        }       
    }
}
