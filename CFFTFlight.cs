﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prg2_assignment
{
    public class CFFTFlight : Flight
    {
        public CFFTFlight(string flightNumber, string origin, string destination, DateTime expectedTime, string status, string airlineName)
            : base(flightNumber, origin, destination, expectedTime, status, airlineName) { }
    }

}
