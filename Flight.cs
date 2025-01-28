using System;

namespace prg2_assignment
{
    public abstract class Flight
    {
       
        
    
   
        public string FlightNumber { get; private set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime ExpectedTime { get; set; }
        public string Status { get; set; }
        public string AirlineName { get; private set; }
        public string SpecialRequestCode { get; set; }
        public string BoardingGateName { get; set; } // New property

        protected Flight(string flightNumber, string origin, string destination, DateTime expectedTime, string status, string airlineName)
        {
            FlightNumber = flightNumber;
            Origin = origin;
            Destination = destination;
            ExpectedTime = expectedTime;
            Status = status;
            AirlineName = airlineName;
            BoardingGateName = "Unassigned"; // Default value
        }
    }

}

