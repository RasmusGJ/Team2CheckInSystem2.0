using System;
using System.Collections.Generic;
using System.Text;

namespace CheckInSystem.Application_Layer
{
    public class CheckInRepo
    {
        public List<CheckIn> CheckIns = new List<CheckIn>();
        private bool CheckIfCheckedIn(Person person)
        {
            return true;
        }

        public void CheckIn(CheckIn checkIn) 
        {
            checkIn.FromTime = DateTime.Now();
        }

        public void CheckOut(Person person)
        {

        }
    }
}
