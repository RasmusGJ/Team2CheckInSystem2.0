using System;
using System.Collections.Generic;
using System.Text;

namespace CheckInSystem.Domain_Layer
{
    public class CheckIn : TimeStamp
    {
		public int Id { get; set; }

		private Mood _mood;

		public Mood mood
		{
			get { return _mood; }
			set { _mood = value; }
		}


		private Person _person;

		public Person person
		{
			get { return _person; }
			set { _person = value; }
		}

	}
}
