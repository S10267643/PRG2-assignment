class DDJBFlight : Flight
{
    public DDJBFlight(string flightNumber, string origin, string destination, string time, string status, string airlineCode)
        : base(flightNumber, origin, destination, time, status, airlineCode) { }

    public override void DisplayFlightInfo()
    {
        Console.WriteLine($"{FlightNumber,-10} {Origin,-10} {Destination,-10} {Time,-8} {Status,-10} {GateName ?? "No Gate"}");
    }
}
