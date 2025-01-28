abstract class Flight
{
    public string FlightNumber { get; }
    public string Origin { get; }
    public string Destination { get; }
    public string Time { get; private set; }
    public string Status { get; private set; }
    public string AirlineCode { get; }
    public string? GateName { get; private set; }

    protected Flight(string flightNumber, string origin, string destination, string time, string status, string airlineCode)
    {
        FlightNumber = flightNumber;
        Origin = origin;
        Destination = destination;
        Time = time;
        Status = status;
        AirlineCode = airlineCode;
        GateName = null;
    }

    public void AssignGate(string gateName)
    {
        GateName = gateName;
    }

    public void ModifyDetails(string newTime, string newStatus)
    {
        Time = newTime;
        Status = newStatus;
    }

    public abstract void DisplayFlightInfo();
}
class ScheduledFlight : Flight
{
    public ScheduledFlight(string flightNumber, string origin, string destination, string time, string status, string airlineCode)
        : base(flightNumber, origin, destination, time, status, airlineCode) { }

    public override void DisplayFlightInfo()
    {
        Console.WriteLine($"{FlightNumber,-10} {Origin,-10} {Destination,-10} {Time,-8} {Status,-10} {GateName ?? "No Gate"}");
    }
}
