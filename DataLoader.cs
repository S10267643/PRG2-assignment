using System;
using System.Collections.Generic;
using System.IO;

class DataLoader
{
    public Dictionary<string, Airline> Airlines { get; private set; } = new Dictionary<string, Airline>();
    public Dictionary<string, BoardingGate> BoardingGates { get; private set; } = new Dictionary<string, BoardingGate>();
    public Dictionary<string, Flight> Flights { get; private set; } = new Dictionary<string, Flight>();

    public void LoadData()
    {
        LoadAirlines("airlines.csv");
        LoadBoardingGates("boardinggates.csv");
        LoadFlights("flights.csv");

        Console.WriteLine($"Total Airlines Loaded: {Airlines.Count}");
        Console.WriteLine($"Total Boarding Gates Loaded: {BoardingGates.Count}");
        Console.WriteLine($"Total Flights Loaded: {Flights.Count}");
    }

    private void LoadAirlines(string filePath)
    {
        foreach (var line in File.ReadAllLines(filePath))
        {
            string[] parts = line.Split(',');
            if (parts.Length < 2) continue;

            string code = parts[0].Trim();
            string name = parts[1].Trim();

            Airlines[code] = new Airline(code, name);
        }
    }

    private void LoadBoardingGates(string filePath)
    {
        foreach (var line in File.ReadAllLines(filePath))
        {
            string gateName = line.Trim();
            if (!string.IsNullOrEmpty(gateName))
            {
                BoardingGates[gateName] = new BoardingGate(gateName);
            }
        }
    }

    private void LoadFlights(string filePath)
    {
        foreach (var line in File.ReadAllLines(filePath))
        {
            string[] parts = line.Split(',');
            if (parts.Length < 5) continue;

            string flightNumber = parts[0].Trim();
            string origin = parts[1].Trim();
            string destination = parts[2].Trim();
            string time = parts[3].Trim();
            string airlineCode = parts[4].Trim();

            if (!Airlines.ContainsKey(airlineCode)) continue;

            Flight flight = new ScheduledFlight(flightNumber, origin, destination, time, "On Time", airlineCode);
            Flights[flightNumber] = flight;
        }
    }
}
