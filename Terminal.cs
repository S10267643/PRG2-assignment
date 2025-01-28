using prg2_assignment;
using System;
using System.Collections.Generic;
using System.Linq;

public class Terminal
{
    
    public Dictionary<string, Airline> Airlines { get; set; }
    public Dictionary<string, BoardingGate> BoardingGates { get; set; }
    public Dictionary<string, Flight> Flights { get; set; }
    public Dictionary<string, double> gateFees { get; set; }
    // Constructor
    public Terminal()
    {
        Airlines = new Dictionary<string, Airline>();
        BoardingGates = new Dictionary<string, BoardingGate>();
        Flights = new Dictionary<string, Flight>();
        gateFees = new Dictionary<string, double>();
    }


    public void AddAirline(Airline airline)
    {
        
    }
    public void AddBoardingGate(BoardingGate gate)
    {
        
    }

    // Method to Add Flight
    public void AddFlight(Flight flight)
    {
        
    }

    // ✅ Fixed DisplayAirlines() to avoid naming conflict
    public void DisplayAirlines()
    {
        
    }

    // ✅ Display Scheduled Flights in Chronological Order
    public void DisplayFlightSchedule()
    {
        
    }

    // ✅ Modify Flight Details
    public void ModifyFlightDetails(string flightNumber, string newStatus, string newGate)
    {
        
    }
    public string ToString()
    {

    }
}

