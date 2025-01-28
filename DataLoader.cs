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
        LoadAirlines();
        LoadBoardingGates();
        LoadFlights();

        Console.WriteLine($"Total Airlines Loaded: {Airlines.Count}");
        Console.WriteLine($"Total Boarding Gates Loaded: {BoardingGates.Count}");
        Console.WriteLine($"Total Flights Loaded: {Flights.Count}");
    }

    private void LoadAirlines()
    {
        string filePath = "airlines.csv";
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Airlines file not found!");
            return;
        }

        using (StreamReader reader = new StreamReader(filePath))
        {
            reader.ReadLine(); // Skip header
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                if (parts.Length >= 2)
                {
                    string code = parts[0].Trim();
                    string name = parts[1].Trim();
                    if (!Airlines.ContainsKey(code))
                        Airlines.Add(code, new Airline(code, name));
                }
            }
        }
    }

    private void LoadBoardingGates()
    {
        string filePath = "boardinggates.csv";
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Boarding gates file not found!");
            return;
        }

        using (StreamReader reader = new StreamReader(filePath))
        {
            reader.ReadLine(); // Skip header
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string gateName = line.Trim();
                if (!string.IsNullOrEmpty(gateName) && !BoardingGates.ContainsKey(gateName))
                    BoardingGates.Add(gateName, new BoardingGate(gateName));
            }
        }
    }

    private void LoadFlights()
    {
        string filePath = "flights.csv";
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Flights file not found!");
            return;
        }

        using (StreamReader reader = new StreamReader(filePath))
        {
            reader.ReadLine(); // Skip header
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                if (parts.Length >= 5)
                {
                    string flightNumber = parts[0].Trim();
                    string origin = parts[1].Trim();
                    string destination = parts[2].Trim();
                    string time = parts[3].Trim();
                    string airlineCode = parts[4].Trim();

                    Flight flight = airlineCode switch
                    {
                        "CFFT" => new CFFTFlight(flightNumber, origin, destination, time, "On Time", airlineCode),
                        "DDJB" => new DDJBFlight(flightNumber, origin, destination, time, "On Time", airlineCode),
                        "LWTT" => new LWTTFlight(flightNumber, origin, destination, time, "On Time", airlineCode),
                        _ => new ScheduledFlight(flightNumber, origin, destination, time, "On Time", airlineCode)
                    };

                    if (!Flights.ContainsKey(flightNumber))
                        Flights.Add(flightNumber, flight);
                }
            }
        }
    }
}
