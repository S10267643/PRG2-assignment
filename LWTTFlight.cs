﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prg2_assignment
{
    public class LWTTFlight : Flight
    {
        public LWTTFlight(string flightNumber, string origin, string destination, DateTime expectedTime, string status)
            : base(flightNumber, origin, destination, expectedTime, status) { }

        public override double CalculateFees()
        {
            return base.CalculateFees() + 500;  // Additional fee for LWTT
        }
        public override string ToString()
        {
            return $"{base.ToString()}, with extended waiting time support.";
        }
    }
}
