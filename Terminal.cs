using System;
using System.Collections.Generic;

class Terminal
{
    private List<Flight> flights;
    private List<BoardingGate> boardingGates;
    private List<Airline> airlines;

    public Terminal()
    {
        flights = new List<Flight>();
        boardingGates = new List<BoardingGate>();
        airlines = new List<Airline>();
    }

    public void AddFlight(Flight flight)
    {
        flights.Add(flight);
    }

    public void AddBoardingGate(BoardingGate gate)
    {
        boardingGates.Add(gate);
    }

    public void AddAirline(Airline airline)
    {
        airlines.Add(airline);
    }

    public void ListFlights()
    {
        Console.WriteLine("\nFlight Number  Airline Name  Origin        Destination   Expected Departure/Arrival Time");
        Console.WriteLine("-------------------------------------------------------------------------------------");
        foreach (var flight in flights)
        {
            flight.DisplayInfo();
        }
    }

    public void ListBoardingGates()
    {
        Console.WriteLine("\nBoarding Gates:");
        Console.WriteLine("----------------");
        foreach (var gate in boardingGates)
        {
            Console.WriteLine(gate.GateName);
        }
    }
    /*public void AssignBoardingGate()
    {
        Console.Write("Enter Flight Number: ");
        string flightNumber = Console.ReadLine();

        if (!flights.ContainsKey(flightNumber))
        {
            Console.WriteLine("Flight not found.");
            return;
        }

        Console.Write("Enter Gate Name: ");
        string gateName = Console.ReadLine();

        if (!boardingGates.ContainsKey(gateName))
        {
            Console.WriteLine("Gate not found.");
            return;
        }

        flights[flightNumber].Gate = boardingGates[gateName];
        Console.WriteLine($"Assigned Gate {gateName} to Flight {flightNumber}");
    }
    public void CreateFlight()
    {
        Console.Write("Enter Flight Number: ");
        string flightNumber = Console.ReadLine();

        Console.Write("Enter Airline Name: ");
        string airlineName = Console.ReadLine();

        Console.Write("Enter Origin: ");
        string origin = Console.ReadLine();

        Console.Write("Enter Destination: ");
        string destination = Console.ReadLine();

        Console.Write("Enter Expected Time (YYYY-MM-DD HH:MM): ");
        DateTime expectedTime = DateTime.Parse(Console.ReadLine());

        Airline airline;
        if (!airlines.ContainsKey(airlineName))
        {
            airline = new Airline(airlineName);
            airlines.Add(airlineName, airline);
        }
        else
        {
            airline = airlines[airlineName];
        }

        Flight newFlight = new Flight(flightNumber, airline, origin, destination, expectedTime);
        flights.Add(flightNumber, newFlight);

        Console.WriteLine("Flight created successfully.");
    }

    public void DisplayAirlineFlights()
    {
        Console.Write("Enter Airline Name: ");
        string airlineName = Console.ReadLine();

        if (!airlines.ContainsKey(airlineName))
        {
            Console.WriteLine("Airline not found.");
            return;
        }

        foreach (var flight in flights.Values)
        {
            if (flight.Airline.Name == airlineName)
            {
                Console.WriteLine($"{flight.FlightNumber} {flight.Origin} {flight.Destination} {flight.ExpectedTime}");
            }
        }
    }

    public void ModifyFlightDetails()
    {
        Console.Write("Enter Flight Number: ");
        string flightNumber = Console.ReadLine();

        if (!flights.ContainsKey(flightNumber))
        {
            Console.WriteLine("Flight not found.");
            return;
        }

        Flight flight = flights[flightNumber];

        Console.Write("Enter New Expected Time (YYYY-MM-DD HH:MM): ");
        flight.ExpectedTime = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Flight details updated.");
    }

    public void DisplayFlightSchedule()
    {
        foreach (var flight in flights.Values)
        {
            Console.WriteLine($"{flight.FlightNumber} {flight.Airline.Name} {flight.Origin} {flight.Destination} {flight.ExpectedTime}");
        }
    }*/


}
