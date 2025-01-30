using System;

abstract class Flight
{
    public string FlightNumber { get; set; }
    public Airline Airline { get; set; }
    public string Origin { get; set; }
    public string Destination { get; set; }
    public DateTime ExpectedTime { get; set; }
    public BoardingGate BoardingGate { get; set; } // Nullable, assigned later

    public Flight(string flightNumber, Airline airline, string origin, string destination, DateTime expectedTime)
    {
        FlightNumber = flightNumber;
        Airline = airline;
        Origin = origin;
        Destination = destination;
        ExpectedTime = expectedTime;
        BoardingGate = null;
    }

    public virtual decimal CalculateFees()
    {
        return 0; // Base method, overridden in subclasses
    }

    public override string ToString()
    {
        return $"{FlightNumber,-10} {Airline.Name,-15} {Origin,-15} {Destination,-15} {ExpectedTime:yyyy-MM-dd HH:mm}";
    }
}
