using prg2_assignment;
using System;
using System.Collections.Generic;
using System.IO;

public static class DataLoader
{
    public static void LoadAirlines(string filePath, Dictionary<string, Airline> airlines)
    {
        foreach (var line in File.ReadAllLines(filePath))
        {
            var parts = line.Split(',');
            if (parts.Length == 2)
            {
                airlines[parts[0]] = new Airline(parts[0], parts[1]);
            }
        }
        Console.WriteLine($"Loaded {airlines.Count} Airlines.");
    }

    public static void LoadBoardingGates(string filePath, Dictionary<string, BoardingGate> boardingGates)
    {
        foreach (var line in File.ReadAllLines(filePath))
        {
            boardingGates[line] = new BoardingGate(line);
        }
        Console.WriteLine($"Loaded {boardingGates.Count} Boarding Gates.");
    }

    public static void LoadFlights(string filePath, Dictionary<string, Flight> flights, Dictionary<string, Airline> airlines)
    {
        foreach (var line in File.ReadAllLines(filePath))
        {
            var parts = line.Split(',');
            if (parts.Length >= 5 && airlines.ContainsKey(parts[1]))
            {
                Airline airline = airlines[parts[1]];
                Flight flight = parts[5] switch
                {
                    "CFFT" => new CFFTFlight(parts[0], airline, parts[2], parts[3], parts[4], "On Time", null),
                    "DDJB" => new DDJBFlight(parts[0], airline, parts[2], parts[3], parts[4], "On Time", null),
                    "LWTT" => new LWTTFlight(parts[0], airline, parts[2], parts[3], parts[4], "On Time", null),
                    _ => null
                };

                if (flight != null)
                {
                    flights[flight.FlightNumber] = flight;
                }
            }
        }
        Console.WriteLine($"Loaded {flights.Count} Flights.");
    }
}
