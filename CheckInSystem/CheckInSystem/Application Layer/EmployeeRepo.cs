using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace CheckInSystem
{
    public class EmployeeRepo
    {
        public List<Employee> employees = new List<Employee>();
        public EmployeeRepo()
        {
            string ConnectionString = "Server=10.56.8.32;Database=A_GRUPEDB02_2019;User Id=A_GRUPE02;Password=A_OPENDB02"; 

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {

                string pinCodeQuery = "SELECT * FROM EMPLOYEE";

                SqlCommand command = new SqlCommand(pinCodeQuery, conn);
                conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Employee employee = new Employee();

                        employee.Name = reader.GetString("Name");
                        employee.Initials = reader.GetString("Initials");
                        employee.LandLine = reader.GetString("LandLine");
                        employee.PinCode = reader.GetString("PinCode");
                        employee.Email = reader.GetString("Email");

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
