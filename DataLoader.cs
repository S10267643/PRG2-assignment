using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

class DataLoader
{
    public Dictionary<string, Airline> Airlines { get; private set; }
    public Dictionary<string, BoardingGate> BoardingGates { get; private set; }
    public Dictionary<string, Flight> Flights { get; private set; }
    private int count;
    
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
   

        using (StreamReader sr = new StreamReader(filename))
        {
            count = 0;
            sr.ReadLine(); // Skip header
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
              
                string code = parts[0].Trim();
                string name = parts[1].Trim();
                count++;

              
            }
        }
        Console.WriteLine("Loading Airlines... ");
        Console.WriteLine(count + " Airlines loaded");
    }

    private void LoadBoardingGates(string filename)
    {
        if (!File.Exists(filename)) return;

        using (StreamReader sr = new StreamReader(filename))
        {
            count = 0;
            sr.ReadLine(); // Skip header
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
             
                string gateName = parts[0].Trim();
                count++;
                
            }
        }
        Console.WriteLine( "Loading BoardingGates... ");
        Console.WriteLine(count + " Boarding Gates Loaded!");
    }
    
    


    public void LoadFlights(string filename)
    {
        if (!File.Exists(filename)) return;

        List<(string FlightNumber, string Origin, string Destination, DateTime ExpectedTime, string SpecialRequest)> flights = new();
        int count = 0;

        using (StreamReader sr = new StreamReader(filename))
        {
            sr.ReadLine(); // Skip header
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = line.Split(',');

                if (parts.Length < 4) continue; // Skip malformed lines

                string flightNumber = parts[0].Trim();
                string origin = parts[1].Trim();
                string destination = parts[2].Trim();
                DateTime expectedTime;

                if (!DateTime.TryParse(parts[3].Trim(), out expectedTime))
                {
                    Console.WriteLine($"Skipping invalid date format: {line}");
                    continue;
                }

                string specialRequest = parts.Length > 4 ? parts[4].Trim() : "N/A"; // Handle missing values

                flights.Add((flightNumber, origin, destination, expectedTime, specialRequest));
                count++;
                
            }
        }
       
        Console.WriteLine("Loading Flights... ");
        Console.WriteLine(count + " Flights Loaded");
    }
}