using System;
using System.Collections.Generic;

class Terminal
{
    private List<Flight> flights;
    private List<BoardingGate> boardingGates;
    private List<Airline> airlines;

    public Terminal()
    {
        flights = new List<Flight>();
        boardingGates = new List<BoardingGate>();
        airlines = new List<Airline>();
    }

    public void AddFlight(Flight flight)
    {
        flights.Add(flight);
    }

    public void AddBoardingGate(BoardingGate gate)
    {
        boardingGates.Add(gate);
    }

    public void AddAirline(Airline airline)
    {
        airlines.Add(airline);
    }

    public void ListFlights()
    {
        Console.WriteLine("\nFlight Number  Airline Name  Origin        Destination   Expected Departure/Arrival Time");
        Console.WriteLine("-------------------------------------------------------------------------------------");
        foreach (var flight in flights)
        {
            flight.DisplayInfo();
        }
    }

    public void ListBoardingGates()
    {
        Console.WriteLine("\nBoarding Gates:");
        Console.WriteLine("----------------");
        foreach (var gate in boardingGates)
        {
            Console.WriteLine(gate.GateName);
        }
    }
}
