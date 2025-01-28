using System;
using System;

public abstract class Flight
{
    public string FlightNumber { get; protected set; }
  
    public string Origin { get; protected set; }
    public string Destination { get; protected set; }
    public string ExpectedTime { get; protected set; }
    public string Status { get; set; }
    public BoardingGate BoardingGate { get; set; }

    public Flight(string flightNumber, string origin, string destination, string time, string status, BoardingGate boardingGate)
    {
        FlightNumber = flightNumber;
        
        Origin = origin;
        Destination = destination;
        ExpectedTime = time;
        Status = status;
        BoardingGate = boardingGate;
    }

    public double CalculateFees()
    {


    }
    public string ToString()
    {
         
    }
}
