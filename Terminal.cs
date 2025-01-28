using System;
using System.Collections.Generic;

class Terminal
{
    private Dictionary<string, Airline> airlines;
    private Dictionary<string, BoardingGate> boardingGates;
    private Dictionary<string, Flight> flights;

    public Terminal(DataLoader dataLoader)
    {
        airlines = dataLoader.Airlines;
        boardingGates = dataLoader.BoardingGates;
        flights = dataLoader.Flights;
    }

    public void ListAllFlights()
    {
        Console.WriteLine("=================================================================================");
        Console.WriteLine("Flight Number   Airline Name        Origin        Destination       Expected");
        Console.WriteLine("=================================================================================");

        foreach (var flight in flights.Values)
        {
            string airlineName = airlines.ContainsKey(flight.FlightNumber.Substring(0, 2))
                                ? airlines[flight.FlightNumber.Substring(0, 2)].Name
                                : "Unknown Airline";

            Console.WriteLine($"{flight.FlightNumber,-15} {airlineName,-20} {flight.Origin,-15} {flight.Destination,-15} {flight.Time}");
        }
    }

    public void ListBoardingGates()
    {
        Console.WriteLine("========================");
        Console.WriteLine("Available Boarding Gates");
        Console.WriteLine("========================");

        foreach (var gate in boardingGates.Values)
        {
            Console.WriteLine(gate.GateName);
        }
    }
}
