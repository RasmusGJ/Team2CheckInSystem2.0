using System;
using System.Collections.Generic;
using System.Text;

namespace CheckInSystem.Domain_Layer
{
    public class Appointment : TimeStamp
    {
        public int Id;
        public Employee Booker;
        public List<Employee> Employees;
        public List<Guest> Guests;
    }
}
