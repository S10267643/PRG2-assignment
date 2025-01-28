using prg2_assignment;

public class CFFTFlight : Flight
{
    public CFFTFlight(string flightNumber, Airline airline, string origin, string destination, string time, string status, BoardingGate boardingGate)
        : base(flightNumber, airline, origin, destination, time, status, boardingGate) { }

    public override void DisplayFlightInfo()
    {
        Console.WriteLine($"CFFT Flight: {FlightNumber}, {Origin} -> {Destination}, Time: {Time}, Status: {Status}, Gate: {BoardingGate?.GateNumber ?? "N/A"}");
    }
}
