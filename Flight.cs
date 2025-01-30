using System;

abstract class Flight
{
    public string FlightNumber { get; private set; }
    public Airline Airline { get; private set; }
    public string Origin { get; private set; }
    public string Destination { get; private set; }
    public DateTime ExpectedTime { get; private set; }
    public BoardingGate Gate { get; private set; } 

    public Flight(string flightNumber, Airline airline, string origin, string destination, DateTime expectedTime)
    {
        FlightNumber = flightNumber;
        Airline = airline;
        Origin = origin;
        Destination = destination;
        ExpectedTime = expectedTime;
        Gate = null; 
    }

    public void AssignGate(BoardingGate gate)
    {
        Gate = gate;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"{FlightNumber,-15} {Airline.Name,-12} {Origin,-12} {Destination,-12} {ExpectedTime:yyyy-MM-dd HH:mm} {Gate?.GateName ?? "N/A"}");
    }

    public abstract double CalculateFees(); 
}
