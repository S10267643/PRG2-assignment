using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

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
        try
        {
            using (StreamReader sr = new StreamReader(filename))
            {
                sr.ReadLine(); // Skip header row
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length < 2) continue;

                    string airlineCode = parts[0].Trim();
                    string airlineName = parts[1].Trim();

                    if (!Airlines.ContainsKey(airlineCode))
                    {
                        Airlines[airlineCode] = new Airline(airlineName);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading airlines: {ex.Message}");
        }
    }

    private void LoadBoardingGates(string filename)
    {
        try
        {
            using (StreamReader sr = new StreamReader(filename))
            {
                sr.ReadLine(); // Skip header row
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
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading boarding gates: {ex.Message}");
        }
    }

    private void LoadFlights(string filename)
    {
        try
        {
            using (StreamReader sr = new StreamReader(filename))
            {
                sr.ReadLine(); // Skip header row
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length < 5) continue;

                    string flightNumber = parts[0].Trim();
                    string airlineCode = parts[1].Trim();
                    string origin = parts[2].Trim();
                    string destination = parts[3].Trim();
                    DateTime expectedTime = DateTime.ParseExact(parts[4].Trim(), "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);

                    if (Airlines.ContainsKey(airlineCode))
                    {
                        Flight flight;
                        if (flightNumber.StartsWith("CFFT"))
                        {
                            flight = new CFFTFlight(flightNumber, Airlines[airlineCode], origin, destination, expectedTime);
                        }
                        else if (flightNumber.StartsWith("DDJB"))
                        {
                            flight = new DDJBFlight(flightNumber, Airlines[airlineCode], origin, destination, expectedTime);
                        }
                        else
                        {
                            continue; // Ignore flights with unknown prefixes
                        }

                        Flights[flightNumber] = flight;
                        Airlines[airlineCode].AddFlight(flight);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading flights: {ex.Message}");
        }
    }
}
