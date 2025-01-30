using System;
using System.Collections.Generic;
using System.IO;

class DataLoader
{
    public Dictionary<string, Airline> Airlines { get; private set; }
    public Dictionary<string, BoardingGate> BoardingGates { get; private set; }
    public Dictionary<string, Flight> Flights { get; private set; }

    public DataLoader()
    {
        Airlines = new Dictionary<string, Airline>();
        BoardingGates = new Dictionary<string, BoardingGate>();
        Flights = new Dictionary<string, Flight>();
    }

    public void LoadData()
    {
        LoadAirlines("airlines.csv");
        LoadBoardingGates("boardinggates.csv");
        LoadFlights("flights.csv");
    }

    private void LoadAirlines(string filename)
    {
        if (!File.Exists(filename)) return;

        using (StreamReader sr = new StreamReader(filename))
        {
            sr.ReadLine(); // Skip header
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                if (parts.Length < 2) continue;
                string code = parts[0].Trim();
                string name = parts[1].Trim();

                if (!Airlines.ContainsKey(code))
                {
                    Airlines[code] = new Airline(code, name);
                }
            }
        }
    }

    private void LoadBoardingGates(string filename)
    {
        if (!File.Exists(filename)) return;

        using (StreamReader sr = new StreamReader(filename))
        {
            sr.ReadLine(); // Skip header
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                if (parts.Length < 1) continue;
                string gateName = parts[0].Trim();

                if (!BoardingGates.ContainsKey(gateName))
                {
                    BoardingGates[gateName] = new BoardingGate(gateName);
                }
            }
        }
    }

    private void LoadFlights(string filename)
    {
        if (!File.Exists(filename)) return;

        using (StreamReader sr = new StreamReader(filename))
        {
            sr.ReadLine(); // Skip header
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                if (parts.Length < 5) continue;

                string flightNumber = parts[0].Trim();
                string airlineCode = parts[1].Trim();
                string origin = parts[2].Trim();
                string destination = parts[3].Trim();
                DateTime expectedTime = DateTime.Parse(parts[4].Trim());

                if (!Airlines.ContainsKey(airlineCode)) continue;

                Airline airline = Airlines[airlineCode];
                Flight flight = new LWTTFlight(flightNumber, airline, origin, destination, expectedTime);
                Flights[flightNumber] = flight;
            }
        }
    }
}
