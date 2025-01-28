using prg2_assignment;
using System;
using System.Collections.Generic;
using System.Linq;

public class Terminal
{
    // Dictionaries to store Airlines, Boarding Gates, and Flights
    private Dictionary<string, Airline> Airlines { get; set; }
    private Dictionary<string, BoardingGate> BoardingGates { get; set; }
    private Dictionary<string, Flight> Flights { get; set; }

    // Constructor
    public Terminal()
    {
        Airlines = new Dictionary<string, Airline>();
        BoardingGates = new Dictionary<string, BoardingGate>();
        Flights = new Dictionary<string, Flight>();
    }


    public void AddAirline(Airline airline)
    {
        if (!Airlines.ContainsKey(airline.Code))
        {
            Airlines.Add(airline.Code, airline);
        }
    }
    public void AddBoardingGate(BoardingGate gate)
    {
        if (!BoardingGates.ContainsKey(gate.GateNumber))
        {
            BoardingGates.Add(gate.GateNumber, gate);
        }
    }

    // Method to Add Flight
    public void AddFlight(Flight flight)
    {
        if (!Flights.ContainsKey(flight.FlightNumber))
        {
            Flights.Add(flight.FlightNumber, flight);
        }
    }

    // ✅ Fixed DisplayAirlines() to avoid naming conflict
    public void DisplayAirlines()
    {
        if (Airlines == null || Airlines.Count == 0)
        {
            Console.WriteLine("No airlines found.");
            return;
        }

        Console.WriteLine("Airline Code    Airline Name");
        foreach (var airlineEntry in Airlines.Values) // Avoids the conflict
        {
            Console.WriteLine($"{airlineEntry.Code,-15} {airlineEntry.Name}");
        }
    }

    // ✅ Display Scheduled Flights in Chronological Order
    public void DisplayScheduledFlights()
    {
        if (Flights == null || Flights.Count == 0)
        {
            Console.WriteLine("No flights available.");
            return;
        }

        Console.WriteLine("\nScheduled Flights (Chronological Order):");
        Console.WriteLine("Flight No   Airline    Origin   Destination   Time     Status    Boarding Gate");

        // Sort flights by departure time
        var sortedFlights = Flights.Values.OrderBy(f => f.Time).ToList();

        foreach (var flight in sortedFlights)
        {
            string gateNumber = flight.BoardingGate?.GateNumber ?? "N/A";
            Console.WriteLine($"{flight.FlightNumber,-10} {flight.Airline.Code,-10} {flight.Origin,-10} {flight.Destination,-12} {flight.Time,-8} {flight.Status,-10} {gateNumber}");
        }
    }

    // ✅ Modify Flight Details
    public void ModifyFlightDetails(string flightNumber, string newStatus, string newGate)
    {
        if (Flights.TryGetValue(flightNumber, out Flight flight))
        {
            flight.Status = newStatus;

            if (BoardingGates.ContainsKey(newGate))
            {
                flight.BoardingGate = BoardingGates[newGate];
            }
            else
            {
                Console.WriteLine($"Error: Boarding Gate {newGate} does not exist.");
                return;
            }

            Console.WriteLine($"Flight {flightNumber} updated: Status = {newStatus}, Gate = {newGate}");
        }
        else
        {
            Console.WriteLine($"Error: Flight {flightNumber} not found.");
        }
    }
}

