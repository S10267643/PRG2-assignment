using System;
using System.Collections.Generic;

class Terminal
{
    private Dictionary<string, Airline> airlines = new Dictionary<string, Airline>();
    private Dictionary<string, BoardingGate> boardingGates = new Dictionary<string, BoardingGate>();
    private Dictionary<string, Flight> flights = new Dictionary<string, Flight>();

    public void AddAirline(Airline airline)
    {
        airlines[airline.Code] = airline;
    }

    public void AddBoardingGate(BoardingGate gate)
    {
        boardingGates[gate.GateName] = gate;
    }

    public void AddFlight(Flight flight)
    {
        flights[flight.FlightNumber] = flight;
    }

    public void ListFlights()
    {
        Console.WriteLine("Flight Number | Origin | Destination | Time | Status");
        Console.WriteLine("-----------------------------------------------------");
        foreach (var flight in flights.Values)
        {
            Console.WriteLine($"{flight.FlightNumber,-12} {flight.Origin,-10} {flight.Destination,-12} {flight.Time,-8} {flight.Status}");
        }
    }

    public void ListBoardingGates()
    {
        Console.WriteLine("Gate Name");
        Console.WriteLine("---------");
        foreach (var gate in boardingGates.Values)
        {
            Console.WriteLine($"{gate.GateName}");
        }
    }

    public void AssignBoardingGate()
    {
        Console.Write("Enter Flight Number: ");
        string flightNumber = Console.ReadLine();
        if (!flights.ContainsKey(flightNumber))
        {
            Console.WriteLine("Error: Flight not found.");
            return;
        }

        Console.Write("Enter Gate Name: ");
        string gateName = Console.ReadLine();
        if (!boardingGates.ContainsKey(gateName))
        {
            Console.WriteLine("Error: Boarding gate not found.");
            return;
        }

        flights[flightNumber].AssignGate(gateName);
        Console.WriteLine($"Gate {gateName} assigned to Flight {flightNumber}.");
    }
}
