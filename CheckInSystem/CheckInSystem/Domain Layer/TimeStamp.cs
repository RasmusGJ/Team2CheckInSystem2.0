using System;
using System.Collections.Generic;
using System.Text;

namespace CheckInSystem.Domain_Layer
{
    public abstract class TimeStamp
    {
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
    }
}
