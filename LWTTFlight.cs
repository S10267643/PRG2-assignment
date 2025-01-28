using prg2_assignment;

public class LWTTFlight : Flight
{
    public LWTTFlight(string flightNumber, Airline airline, string origin, string destination, string time, string status, BoardingGate boardingGate)
        : base(flightNumber, airline, origin, destination, time, status, boardingGate) { }

    public override void DisplayFlightInfo()
    {
        Console.WriteLine($"LWTT Flight: {FlightNumber}, {Origin} -> {Destination}, Time: {Time}, Status: {Status}, Gate: {BoardingGate?.GateNumber ?? "N/A"}");
    }
}
