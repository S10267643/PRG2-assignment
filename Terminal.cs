using System;
using System.Collections.Generic;
using System.Linq;

namespace prg2_assignment
{
    public class Terminal
    {
        public string TerminalName { get; private set; }
        public Dictionary<string, Airline> Airlines { get; private set; }
        public Dictionary<string, BoardingGate> BoardingGates { get; private set; }
        public Dictionary<string, Flight> Flights { get; private set; }

        public Terminal(string terminalName)
        {
            TerminalName = terminalName;
            Airlines = new Dictionary<string, Airline>();
            BoardingGates = new Dictionary<string, BoardingGate>();
            Flights = new Dictionary<string, Flight>();
        }

        /// <summary>
        /// Adds an airline to the terminal.
        /// </summary>
        public bool AddAirline(Airline airline)
        {
            if (!Airlines.ContainsKey(airline.Code))
            {
                Airlines.Add(airline.Code, airline);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Adds a boarding gate to the terminal.
        /// </summary>
        public bool AddBoardingGate(BoardingGate gate)
        {
            if (!BoardingGates.ContainsKey(gate.GateName))
            {
                BoardingGates.Add(gate.GateName, gate);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Adds a flight to the terminal and associates it with an airline if applicable.
        /// </summary>
        public bool AddFlight(Flight flight)
        {
            if (!Flights.ContainsKey(flight.FlightNumber))
            {
                Flights.Add(flight.FlightNumber, flight);

                // Associate the flight with its airline
                if (Airlines.ContainsKey(flight.AirlineName))
                {
                    Airlines[flight.AirlineName].Flights[flight.FlightNumber] = flight;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Displays the loaded airlines, boarding gates, and flights.
        /// </summary>
        public void DisplayLoadedData()
        {
            Console.WriteLine($"{Airlines.Count} Airlines Loaded!");
            Console.WriteLine($"{BoardingGates.Count} Boarding Gates Loaded!");
            Console.WriteLine($"{Flights.Count} Flights Loaded!");
        }

        /// <summary>
        /// Lists all flights with basic information.
        /// </summary>
        public void ListAllFlights()
        {
            Console.WriteLine("=============================================");
            Console.WriteLine("List of Flights for Changi Airport Terminal 5");
            Console.WriteLine("=============================================");
            Console.WriteLine("Flight Number   Airline Name           Origin                 Destination            Expected Time");
            foreach (var flight in Flights.Values.OrderBy(f => f.ExpectedTime))
            {
                Console.WriteLine($"{flight.FlightNumber,-15} {flight.AirlineName,-20} {flight.Origin,-20} {flight.Destination,-20} {flight.ExpectedTime:g}");
            }
        }

        /// <summary>
        /// Lists all boarding gates and their supported special request codes.
        /// </summary>
        public void ListAllBoardingGates()
        {
            Console.WriteLine("=============================================");
            Console.WriteLine("List of Boarding Gates for Changi Airport Terminal 5");
            Console.WriteLine("=============================================");
            Console.WriteLine("Gate Name       DDJB                   CFFT                   LWTT");
            foreach (var gate in BoardingGates.Values)
            {
                Console.WriteLine($"{gate.GateName,-15} {gate.SupportsDDJB,-20} {gate.SupportsCFFT,-20} {gate.SupportsLWTT,-20}");
            }
        }

        /// <summary>
        /// Assigns a boarding gate to a flight.
        /// </summary>
        public void AssignBoardingGateToFlight(string flightNumber, string gateName)
        {
            if (Flights.ContainsKey(flightNumber) && BoardingGates.ContainsKey(gateName))
            {
                var flight = Flights[flightNumber];
                var gate = BoardingGates[gateName];

                Console.WriteLine("Flight Details:");
                Console.WriteLine($"Flight Number: {flight.FlightNumber}");
                Console.WriteLine($"Origin: {flight.Origin}");
                Console.WriteLine($"Destination: {flight.Destination}");
                Console.WriteLine($"Expected Time: {flight.ExpectedTime:g}");
                Console.WriteLine($"Special Request Code: {(flight is CFFTFlight ? "CFFT" : flight is DDJBFlight ? "DDJB" : flight is LWTTFlight ? "LWTT" : "None")}");
                Console.WriteLine($"Assigned Boarding Gate: {gate.GateName}");
            }
            else
            {
                Console.WriteLine("Invalid flight number or gate name.");
            }
        }
    }
}
