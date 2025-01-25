

using System;
using System.Collections.Generic;
using System.IO;


using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static Dictionary<string, Airline> airlinesDict = new Dictionary<string, Airline>();
    static Dictionary<string, BoardingGate> boardingGatesDict = new Dictionary<string, BoardingGate>();
    static Dictionary<string, Flight> flightsDict = new Dictionary<string, Flight>();

    static void Main(string[] args)
    {
        LoadAirlines("airlines.csv");
        LoadBoardingGates("boardinggates.csv");
        LoadFlights("flights.csv");

        // Display loaded data
        Console.WriteLine("\nLoaded Airlines:");
        foreach (var airline in airlinesDict)
        {
            Console.WriteLine($"{airline.Key}: {airline.Value.Name}");
        }

        Console.WriteLine("\nLoaded Boarding Gates:");
        foreach (var gate in boardingGatesDict)
        {
            Console.WriteLine($"{gate.Key}: Special Requests - {string.Join(", ", gate.Value.SpecialRequests)}");
        }

        Console.WriteLine("\nLoaded Flights:");
        foreach (var flight in flightsDict)
        {
            Console.WriteLine($"{flight.Key}: {flight.Value.AirlineName} from {flight.Value.Origin} to {flight.Value.Destination} at {flight.Value.ExpectedTime} ({flight.Value.Status})");
        }
    }

    static void LoadAirlines(string filePath)
    {
        int count = 0;
        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                reader.ReadLine(); // Skip header
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(',');
                    string code = parts[0];
                    string name = parts[1];
                    airlinesDict[code] = new Airline(code, name);
                    count++;
                }
                Console.WriteLine($"Airlines loaded successfully! Total: {count}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error loading airlines: {e.Message}");
        }
    }

    static void LoadBoardingGates(string filePath)
    {
        int count = 0;
        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                reader.ReadLine(); // Skip header
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(',');
                    string gate = parts[0];
                    List<string> specialRequests = parts.Length > 1 ? new List<string>(parts[1].Split(';')) : new List<string>();
                    boardingGatesDict[gate] = new BoardingGate(gate, specialRequests);
                    count++;
                }
                Console.WriteLine($"Boarding gates loaded successfully! Total: {count}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error loading boarding gates: {e.Message}");
        }
    }

    static void LoadFlights(string filePath)
    {
        int count = 0;
        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                reader.ReadLine(); // Skip header
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(',');
                    string flightNumber = parts[0];
                    string airlineName = parts[1];
                    string origin = parts[2];
                    string destination = parts[3];
                    string expectedTime = parts[4];
                    string status = parts.Length > 5 ? parts[5] : "On Time";
                    flightsDict[flightNumber] = new Flight(flightNumber, airlineName, origin, destination, expectedTime, status);
                    count++;
                }
                Console.WriteLine($"Flights loaded successfully! Total: {count}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error loading flights: {e.Message}");
        }
    }
}

public class Airline
{
    public string Code { get; set; }
    public string Name { get; set; }

    public Airline(string code, string name)
    {
        Code = code;
        Name = name;
    }
}

public class BoardingGate
{
    public string Gate { get; set; }
    public List<string> SpecialRequests { get; set; }

    public BoardingGate(string gate, List<string> specialRequests)
    {
        Gate = gate;
        SpecialRequests = specialRequests;
    }
}

public class Flight
{
    public string FlightNumber { get; set; }
    public string AirlineName { get; set; }
    public string Origin { get; set; }
    public string Destination { get; set; }
    public string ExpectedTime { get; set; }
    public string Status { get; set; }

    public Flight(string flightNumber, string airlineName, string origin, string destination, string expectedTime, string status = "On Time")
    {
        FlightNumber = flightNumber;
        AirlineName = airlineName;
        Origin = origin;
        Destination = destination;
        ExpectedTime = expectedTime;
        Status = status;
    }
}
