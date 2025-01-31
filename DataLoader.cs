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
    
    

    private void LoadFlights(string filename)
    {
        if (!File.Exists(filename)) return;

        using (StreamReader sr = new StreamReader(filename))
        {
            sr.ReadLine(); // Skip header
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                count = 0;
                string[] parts = line.Split(',');
               

                string flightNumber = parts[0].Trim();
                string airlineCode = parts[1].Trim();
                string origin = parts[2].Trim();
                string destination = parts[3].Trim();
                DateTime expectedTime = DateTime.Parse(parts[4].Trim());
                count++;

               
            }
        }
        Console.WriteLine("Loading Flights... ");
        Console.WriteLine(count + " Flights Loaded");
    }
}
