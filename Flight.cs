using System;

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

        protected Flight(string flightNumber, string origin, string destination, DateTime expectedTime, string status, string airlineName)
        {
            FlightNumber = flightNumber;
            Origin = origin;
            Destination = destination;
            ExpectedTime = expectedTime;
            Status = status;
            AirlineName = airlineName;
        }
    }
}

