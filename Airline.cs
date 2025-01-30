using System;
using System.Collections.Generic;

public class Airline
{
    public string code {  get; set; }
    public string Name { get; }
    private List<Flight> flights;

    public Airline(string name)
    {
        Name = name;
        flights = new List<Flight>();
    }

 
    public int GetFlightCount()
    {
        return flights.Count;
    }
}
