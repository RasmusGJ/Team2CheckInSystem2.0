using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace CheckInSystem
{
    public class Controller
    {
        public EmployeeRepo employeesRepo = new EmployeeRepo();

        public bool VerifyPin(string pinCode)
        {
            foreach(var i in employeesRepo.employees)
            {
                if (pinCode == i.PinCode)
                {
                    //employeesRepo.EmployeeNameBind = i.Name;
                    return true;
                }               
            }
            return false;          
        }
        public void UpdateCheckInTime()
        {

        }

        public void AssignMood()
        {

        }
    }
}
