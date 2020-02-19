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
            MoodWindow moodWindow = new MoodWindow();
            moodWindow.Show();
            return true;

            
        }
        public void UpdateCheckInTime()
        {

        }

        public void AssignMood()
        {

        }
    }
}
