using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prg2_assignment
{
    public abstract class Flight
    {
        public string FlightNumber { get; private set; }
        public string Origin { get; private set; }
        public string Destination { get; private set; }
        public DateTime ExpectedTime { get; private set; }
        public string Status { get; private set; }
        public string AirlineName { get; private set; }

        public Flight(string flightNumber, string origin, string destination, DateTime expectedTime, string status)
        {
            FlightNumber = flightNumber;
            Origin = origin;
            Destination = destination;
            ExpectedTime = expectedTime;
            Status = status;
        }

        //basic fee
        public virtual double CalculateFees()
        {
            double fee = 0;
            if (Destination == "SIN")
            {
                fee += 500; // Arriving flight fee
            }
            if (Origin == "SIN")
            {
                fee += 800; // Departing flight fee
            }
            fee += 300; // Base gate fee
            return fee;
        }

        public override string ToString()
        {
            return $"Flight {FlightNumber} from {Origin} to {Destination}, due {ExpectedTime:g}, Status: {Status}";
        }
    }

}
