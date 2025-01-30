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
    }

    private void LoadAirlines(string fileName)
    {
        foreach (var line in File.ReadAllLines(fileName))
        {
            var data = line.Split(',');
            Airlines[data[0]] = new Airline(data[0], data[1]);
        }
    }

    private void LoadBoardingGates(string fileName)
    {
        foreach (var line in File.ReadAllLines(fileName))
        {
            BoardingGates[line] = new BoardingGate(line);
        }
    }

    private void LoadFlights(string fileName)
    {
        foreach (var line in File.ReadAllLines(fileName))
        {
            var data = line.Split(',');
            if (Airlines.ContainsKey(data[1]))
            {
                Flights[data[0]] = new LWTTFlight(data[0], Airlines[data[1]], data[2], data[3], DateTime.Parse(data[4]), bool.Parse(data[5]), bool.Parse(data[6]));
            }
        }
    }
}
