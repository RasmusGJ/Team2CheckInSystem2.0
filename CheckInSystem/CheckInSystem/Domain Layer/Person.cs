﻿using System;
using System.Collections.Generic;
using System.Text;
using CheckInSystem.Application_Layer;

namespace CheckInSystem.Domain_Layer
{
    public abstract class Person
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public int Id { get; set; }
    }
}
