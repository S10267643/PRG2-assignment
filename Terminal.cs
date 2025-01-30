using System;
using System.Collections.Generic;

class Terminal
{
    private List<Flight> flights;
    private List<BoardingGate> boardingGates;
    private Dictionary<string, Airline> airlines;

    public Terminal()
    {
        flights = new List<Flight>();
        boardingGates = new List<BoardingGate>();
        airlines = new Dictionary<string, Airline>();
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
        if (!airlines.ContainsKey(airline.Name))
        {
            airlines[airline.Name] = airline;
        }
    }

    public void ListFlights()
    {
        Console.WriteLine("=================================================================================");
        Console.WriteLine("FLIGHT NUMBER  AIRLINE NAME  ORIGIN       DESTINATION      EXPECTED TIME");
        Console.WriteLine("=================================================================================");
        foreach (var flight in flights)
        {
            Console.WriteLine($"{flight.FlightNumber,-15} {flight.Airline.Name,-12} {flight.Origin,-12} {flight.Destination,-12} {flight.ExpectedTime:yyyy-MM-dd HH:mm}");
        }
        Console.WriteLine("=================================================================================");
    }

    public void ListBoardingGates()
    {
        Console.WriteLine("BOARDING GATES:");
        foreach (var gate in boardingGates)
        {
            Console.WriteLine($"- {gate.GateName}");
        }
    }

   
    public void AssignBoardingGate()
    {
        Console.Write("Enter flight number: ");
        string flightNumber = Console.ReadLine().Trim();

        Flight flight = flights.Find(f => f.FlightNumber == flightNumber);
        if (flight == null)
        {
            Console.WriteLine("Flight not found.");
            return;
        }

        Console.Write("Enter boarding gate name: ");
        string gateName = Console.ReadLine().Trim();

        BoardingGate gate = boardingGates.Find(g => g.GateName == gateName);
        if (gate == null)
        {
            Console.WriteLine("Boarding gate not found.");
            return;
        }

        flight.AssignGate(gate);
        Console.WriteLine($"Boarding gate {gate.GateName} assigned to flight {flight.FlightNumber}.");
    }

}
