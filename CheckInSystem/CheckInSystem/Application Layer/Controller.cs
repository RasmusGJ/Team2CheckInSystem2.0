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
        public EmployeeRepo employeesRepo;

        public bool VerifyPin(string pinCode)
        {
            foreach(var i in employeesRepo.employees)
            {
                if (pinCode == i.PinCode)
                {
                    MoodWindow moodWindow = new MoodWindow();
                    moodWindow.Show();
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
