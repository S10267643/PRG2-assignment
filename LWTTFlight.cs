namespace prg2_assignment
{
    public class LWTTFlight : Flight
    {
        public LWTTFlight(string flightNumber, string origin, string destination, DateTime expectedTime, string status, string airlineName)
            : base(flightNumber, origin, destination, expectedTime, status, airlineName)
        {
        }
    }
}
