

using System;
using System.Collections.Generic;
using System.IO;


//==========================================================
// Student Number	: S10267904
// Student Name	: amir daiyan
// Partner Name	: ashton leu
//==========================================================




public class Terminal
{
    public string TerminalName { get; set; }
    public Dictionary<string, Airline> Airlines { get; private set; } = new Dictionary<string, Airline>();
    public Dictionary<string, Flight> Flights { get; private set; } = new Dictionary<string, Flight>();
    public Dictionary<string, BoardingGate> BoardingGates { get; private set; } = new Dictionary<string, BoardingGate>();
    public Dictionary<string, double> GateFees { get; private set; } = new Dictionary<string, double>();

    public Terminal(string name)
    {
        TerminalName = name;
    }

    public bool AddAirline(Airline airline)
    {
        if (!Airlines.ContainsKey(airline.Code))
        {
            Airlines.Add(airline.Code, airline);
            return true;
        }
        return false;
    }

    public bool AddBoardingGate(BoardingGate gate)
    {
        if (!BoardingGates.ContainsKey(gate.GateName))
        {
            BoardingGates.Add(gate.GateName, gate);
            return true;
        }
        return false;
    }

    public Airline GetAirlineFromFlight(Flight flight)
    {
        return Airlines.ContainsKey(flight.AirlineName) ? Airlines[flight.AirlineName] : null;
    }


    public override string ToString()
    {
        return $"Terminal {TerminalName} hosts {Airlines.Count} airlines.";
    }

    public void PrintAirlineFees()
    {
        foreach (var airline in Airlines)
        {
            double totalFees = 0;
            int countFlights = airline.Value.Flights.Count;

            foreach (var flight in airline.Value.Flights.Values)
            {
                totalFees += flight.CalculateFees();
            }

            // Applying promotions
            double discount = 0;
            discount += (countFlights / 3) * 350; // $350 discount for every 3 flights
            foreach (var flight in airline.Value.Flights.Values)
            {
                if (flight.ExpectedTime.Hour < 11 || flight.ExpectedTime.Hour > 21)
                    discount += 110; // Early or late flight discount
                if (flight.Origin == "DXB" || flight.Origin == "BKK" || flight.Origin == "NRT")
                    discount += 25; // Specific origin discount
                if (string.IsNullOrEmpty(flight.Status)) // Assuming no special request is marked by empty status
                    discount += 50;
            }
            if (countFlights > 5)
                discount += totalFees * 0.03; // 3% off the total bill for more than 5 flights

            Console.WriteLine($"{airline.Key} owes: {totalFees - discount} in fees after discounts.");
        }
    }

}

public class Airline
{
    public string Name { get; private set; }
    public string Code { get; private set; }
    public Dictionary<string, Flight> Flights { get; private set; } = new Dictionary<string, Flight>();

    public Airline(string code, string name)
    {
        Code = code;
        Name = name;
    }

    public bool AddFlight(Flight flight)
    {
        if (!Flights.ContainsKey(flight.FlightNumber))
        {
            Flights.Add(flight.FlightNumber, flight);
            return true;
        }
        return false;
    }

    public bool RemoveFlight(string flightNumber)
    {
        return Flights.Remove(flightNumber);
    }

    public double CalculateFees()
    {
        double totalFees = 0;
        foreach (var flight in Flights.Values)
        {
            totalFees += flight.CalculateFees();
        }
        return totalFees;
    }

    public override string ToString()
    {
        return $"{Name} ({Code})";
    }
}



public class BoardingGate
{
    public string GateName { get; private set; }
    public bool SupportsCFFT { get; private set; }
    public bool SupportsDDJB { get; private set; }
    public bool SupportsLWTT { get; private set; }
    public Flight AssignedFlight { get; set; }

    public BoardingGate(string gateName, bool supportsCFFT, bool supportsDDJB, bool supportsLWTT)
    {
        GateName = gateName;
        SupportsCFFT = supportsCFFT;
        SupportsDDJB = supportsDDJB;
        SupportsLWTT = supportsLWTT;
    }

    public double CalculateFees()
    {
        double fee = 300; // Base fee
        if (SupportsCFFT) fee += 150;
        if (SupportsDDJB) fee += 300;
        if (SupportsLWTT) fee += 500;
        return fee;
    }

    public override string ToString()
    {
        return $"{GateName} supports CFFT: {SupportsCFFT}, DDJB: {SupportsDDJB}, LWTT: {SupportsLWTT}";
    }
}

public class Flight
{
    public string FlightNumber { get; private set; }
    public string Origin { get; private set; }
    public string Destination { get; private set; }
    public DateTime ExpectedTime { get; private set; }
    public string Status { get; private set; }
    public string AirlineName { get; private set; }

    public Flight(string flightNumber, string origin, string destination, DateTime expectedTime, string status)
    {
        FlightNumber = flightNumber;
        Origin = origin;
        Destination = destination;
        ExpectedTime = expectedTime;
        Status = status;
    }

    //basic fee
    public virtual double CalculateFees()
    {
        double fee = 0;
        if (Destination == "SIN")
        {
            fee += 500; // Arriving flight fee
        }
        if (Origin == "SIN")
        {
            fee += 800; // Departing flight fee
        }
        fee += 300; // Base gate fee
        return fee;
    }

    public override string ToString()
    {
        return $"Flight {FlightNumber} from {Origin} to {Destination}, due {ExpectedTime:g}, Status: {Status}";
    }
}

public class CFFTFlight : Flight
{
    public CFFTFlight(string flightNumber, string origin, string destination, DateTime expectedTime, string status)
        : base(flightNumber, origin, destination, expectedTime, status) { }

    public override double CalculateFees()
    {
        return base.CalculateFees() + 150;  // Additional fee for CFFT
    }
    public override string ToString()
    {
        return $"{base.ToString()}, with CFFT support.";
    }
}

public class DDJBFlight : Flight
{
    public DDJBFlight(string flightNumber, string origin, string destination, DateTime expectedTime, string status)
        : base(flightNumber, origin, destination, expectedTime, status) { }

    public override double CalculateFees()
    {
        return base.CalculateFees() + 300;  // Additional fee for DDJB
    }
    public override string ToString()
    {
        return $"{base.ToString()}, with DDJB support.";
    }
}

public class LWTTFlight : Flight
{
    public LWTTFlight(string flightNumber, string origin, string destination, DateTime expectedTime, string status)
        : base(flightNumber, origin, destination, expectedTime, status) { }

    public override double CalculateFees()
    {
        return base.CalculateFees() + 500;  // Additional fee for LWTT
    }
    public override string ToString()
    {
        return $"{base.ToString()}, with extended waiting time support.";
    }
}



public class DataLoader
{
    public static void LoadAirlines(string filepath, Dictionary<string, Airline> airlines)
    {
        using (var reader = new StreamReader(filepath))
        {
            reader.ReadLine(); // Assuming the first line is headers
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                var airline = new Airline(values[0], values[1]);
                airlines.Add(airline.Code, airline);
            }
        }
    }

    public static void LoadBoardingGates(string filepath, Dictionary<string, BoardingGate> gates)
    {
        using (var reader = new StreamReader(filepath))
        {
            reader.ReadLine(); // Assuming the first line is headers
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                var gate = new BoardingGate(values[0], bool.Parse(values[1]), bool.Parse(values[2]), bool.Parse(values[3]));
                gates.Add(gate.GateName, gate);
            }
        }
    }

    public static void LoadFlights(string filepath, Dictionary<string, Flight> flights)
    {
        using (var reader = new StreamReader(filepath))
        {
            reader.ReadLine(); // Assuming the first line is headers
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                DateTime expectedTime;
                DateTime.TryParse(values[3], out expectedTime);
                var flight = new Flight(values[0], values[1], values[2], expectedTime, values[4]);
                flights.Add(flight.FlightNumber, flight);
            }
        }
    }
}

class Program
{
    static void Main()
    {
        var airlines = new Dictionary<string, Airline>();
        DataLoader.LoadAirlines("airlines.csv", airlines);

        var gates = new Dictionary<string, BoardingGate>();
        DataLoader.LoadBoardingGates("boardinggates.csv", gates);

        var flights = new Dictionary<string, Flight>();
        DataLoader.LoadFlights("flights.csv", flights);

        // Display loaded data
        Console.WriteLine("Airlines loaded:");
        foreach (var airline in airlines.Values)
        {
            Console.WriteLine(airline);
        }

        Console.WriteLine("Gates loaded:");
        foreach (var gate in gates.Values)
        {
            Console.WriteLine(gate);
        }

        Console.WriteLine("Flights loaded:");
        foreach (var flight in flights.Values)
        {
            Console.WriteLine(flight);
        }
    }
}
