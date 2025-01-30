using System;
using System.Collections.Generic;

class Airline
{
    public string Name { get; }
    private List<Flight> flights;

    public Airline(string name)
    {
        Name = name;
        flights = new List<Flight>();
    }

    public void AddFlight(Flight flight)
    {
        flights.Add(flight);
    }

    public int GetFlightCount()
    {
        return flights.Count;
    }
}
