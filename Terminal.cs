using System;
using System.Collections.Generic;
using System.Linq;

class Terminal
{
    private List<Flight> flights = new List<Flight>();
    private List<BoardingGate> boardingGates = new List<BoardingGate>();
    private Dictionary<string, Airline> airlines = new Dictionary<string, Airline>();

    public void AddFlight(Flight flight) => flights.Add(flight);
    public void AddBoardingGate(BoardingGate gate) => boardingGates.Add(gate);
    public void AddAirline(Airline airline) => airlines[airline.Code] = airline;

    public void ListFlights()
    {
        Console.WriteLine("=====================================================================");
        Console.WriteLine("Flight Number Airline Name     Origin          Destination      Expected");
        Console.WriteLine("=====================================================================");
        foreach (var flight in flights)
        {
            Console.WriteLine(flight);
        }
        Console.WriteLine("=====================================================================");
    }

    public void ListBoardingGates()
    {
        Console.WriteLine("===============================");
        Console.WriteLine("Gate Name       Status");
        Console.WriteLine("===============================");
        foreach (var gate in boardingGates)
        {
            Console.WriteLine($"{gate.GateName,-15} {(gate.IsOccupied ? "Occupied" : "Available")}");
        }
        Console.WriteLine("===============================");
    }

    public void AssignBoardingGate()
    {
        Console.Write("Enter Flight Number: ");
        string flightNumber = Console.ReadLine();
        var flight = flights.FirstOrDefault(f => f.FlightNumber == flightNumber);
        if (flight == null)
        {
            Console.WriteLine("Flight not found.");
            return;
        }

        Console.Write("Enter Boarding Gate: ");
        string gateName = Console.ReadLine();
        var gate = boardingGates.FirstOrDefault(g => g.GateName == gateName);
        if (gate == null || gate.IsOccupied)
        {
            Console.WriteLine("Invalid gate or already occupied.");
            return;
        }

        flight.BoardingGate = gate;
        gate.IsOccupied = true;
        Console.WriteLine($"Gate {gate.GateName} assigned to flight {flight.FlightNumber}.");
    }
}
