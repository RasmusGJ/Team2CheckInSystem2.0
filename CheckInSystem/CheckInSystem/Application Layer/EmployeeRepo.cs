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
                        employee.Name = String.IsNullOrEmpty(reader.GetString("Name")) ? " " : reader.GetString("Name");
                        employee.Initials = String.IsNullOrEmpty(reader.GetString("Initials")) ? " " : reader.GetString("Initials");
                        employee.LandlinePhone = String.IsNullOrEmpty(reader.GetString("LandlinePhone")) ? " " : reader.GetString("LandlinePhone");
                        employee.PinCode = String.IsNullOrEmpty(reader.GetString("PinCode")) ? " " : reader.GetString("PinCode");
                        employee.Email = String.IsNullOrEmpty(reader.GetString("Email")) ? " " : reader.GetString("Email");
                        employee.Role = String.IsNullOrEmpty(reader.GetString("RoleTitle")) ? " " : reader.GetString("RoleTitle");
                        employee.MobilePhone = String.IsNullOrEmpty(reader.GetString("MobilePhone")) ? " " : reader.GetString("MobilePhone");
                        employee.Department = String.IsNullOrEmpty(reader.GetString("DepartmentTitle")) ? " " : reader.GetString("DepartmentTitle");
                        employee.Id = reader.GetInt32("Id");
                        employees.Add(employee);
                    }
                }
            }
        }       

        public void AddEmployee()
        {

        }

        /*private string name = "rasser";
        public string EmployeeNameBind { get { return name; } set { name = value; OnPropertyChanged("EmployeeNameBind"); }  }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }*/
    }
}
