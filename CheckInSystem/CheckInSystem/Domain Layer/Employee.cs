using System;
using System.Collections.Generic;
using System.Text;

namespace CheckInSystem
{
    public class Employee : Person
    {
        public string IMG { get; set; }
        public string Initials { get; set; }
        public string LandLine { get; set; }
        public string PinCode { get; set; }
        public string Department { get; set; }
        public string Role { get; set; }

        public Employee(/*string img, string initials, string landLinePhone, string pinCode, string department, string role*/)
        {
            /*IMG = img;
            Initials = initials;
            LandLinePhone = landLinePhone;
            PinCode = PinCode;
            Department = department;
            Role = role;*/
        }

    }
}
