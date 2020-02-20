using System;
using System.Collections.Generic;
using System.Text;

namespace CheckInSystem
{
    public abstract class Person
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string Id { get; set; }
    }
}
