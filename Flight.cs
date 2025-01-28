using System;
using System;

public abstract class Flight
{
    public string FlightNumber { get; protected set; }
    public Airline Airline { get; protected set; }
    public string Origin { get; protected set; }
    public string Destination { get; protected set; }
    public string Time { get; protected set; }
    public string Status { get; set; }
    public BoardingGate BoardingGate { get; set; }

    public Flight(string flightNumber, Airline airline, string origin, string destination, string time, string status, BoardingGate boardingGate)
    {
        FlightNumber = flightNumber;
        Airline = airline;
        Origin = origin;
        Destination = destination;
        Time = time;
        Status = status;
        BoardingGate = boardingGate;
    }

    public abstract void DisplayFlightInfo();
}
