using System;
using System.Collections.Generic;
using System.Text;

namespace CheckInSystem
{
    public class CheckIn
    {
        private Mood mood;

		private Person _person;

		public Person person
		{
			get { return _person; }
			set { _person = value; }
		}

	}
}
