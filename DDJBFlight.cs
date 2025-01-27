using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prg2_assignment
{
    public class DDJBFlight : Flight
    {
        public DDJBFlight(string flightNumber, string origin, string destination, DateTime expectedTime, string status)
            : base(flightNumber, origin, destination, expectedTime, status) { }

        public override double CalculateFees()
        {
            return base.CalculateFees() + 300;  // Additional fee for DDJB
        }
        public override string ToString()
        {
            return $"{base.ToString()}, with DDJB support.";
        }
    }
}
