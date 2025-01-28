using prg2_assignment;

public class Terminal
{
    public Dictionary<string, Airline> Airlines { get; private set; }
    public Dictionary<string, BoardingGate> BoardingGates { get; private set; }
    public Dictionary<string, Flight> Flights { get; private set; }

    public Terminal()
    {
        Airlines = new Dictionary<string, Airline>();
        BoardingGates = new Dictionary<string, BoardingGate>();
        Flights = new Dictionary<string, Flight>();
    }

    /// <summary>
    /// Adds an airline to the terminal.
    /// </summary>
    /// <param name="airline">The airline to add.</param>
    public void AddAirline(Airline airline)
    {
        if (!Airlines.ContainsKey(airline.Code))
        {
            Airlines.Add(airline.Code, airline);
        }
    }

    /// <summary>
    /// Adds a boarding gate to the terminal.
    /// </summary>
    /// <param name="gate">The boarding gate to add.</param>
    public void AddBoardingGate(BoardingGate gate)
    {
        if (!BoardingGates.ContainsKey(gate.GateName))
        {
            BoardingGates.Add(gate.GateName, gate);
        }
    }

    /// <summary>
    /// Adds a flight to the terminal and associates it with the corresponding airline.
    /// </summary>
    /// <param name="flight">The flight to add.</param>
    public void AddFlight(Flight flight)
    {
        if (!Flights.ContainsKey(flight.FlightNumber))
        {
            Flights.Add(flight.FlightNumber, flight);

            // If the airline exists, associate the flight with the airline.
            if (Airlines.ContainsKey(flight.AirlineName))
            {
                Airlines[flight.AirlineName].Flights[flight.FlightNumber] = flight;
            }
        }
    }
}
