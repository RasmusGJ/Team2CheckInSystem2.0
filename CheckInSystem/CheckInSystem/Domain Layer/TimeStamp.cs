using System;
using System.Collections.Generic;
using System.Text;

namespace CheckInSystem.Domain_Layer
{
    public abstract class TimeStamp
    {
		private DateTime fromTime;

		public DateTime FromTime;
		{
			get { return fromTime; }
			set { fromTime = value; }
		}

	}
}
