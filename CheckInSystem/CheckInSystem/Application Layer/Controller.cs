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
        public string empNameWelcomeWindow;
        public string empNameMoodWindow;
        
        public bool VerifyPin(string pinCode)
        {
            //Checks if the parameter pinCode matches PinCode property in employees list.
            foreach(Employee i in employeesRepo.employees)
            {
                if (pinCode == i.PinCode)
                {
                    empNameWelcomeWindow = i.Name;
                    empNameMoodWindow = i.Name;
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
