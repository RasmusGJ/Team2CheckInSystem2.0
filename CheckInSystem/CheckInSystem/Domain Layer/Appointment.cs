using System;
using System.Collections.Generic;
using System.Text;

namespace CheckInSystem.Domain_Layer
{
    public class Appointment : TimeStamp
    {
        public int Id;
        public Employee Booker;
        public List<Employee> Employees = new List<Employee>();
        public List<Guest> Guests = new List<Guest>();
    }
}
