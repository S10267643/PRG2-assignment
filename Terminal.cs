using System;
using System.Collections.Generic;
using System.Linq;

namespace prg2_assignment
{
    public class Terminal
    {
        // Properties
        public Dictionary<string, Airline> Airlines { get; private set; }
        public Dictionary<string, BoardingGate> BoardingGates { get; private set; }
        public Dictionary<string, Flight> Flights { get; private set; }
        public string TerminalName { get; private set; }

        // Constructor
        public Terminal(string terminalName = "Changi Airport Terminal 5")
        {
            TerminalName = terminalName;
            Airlines = new Dictionary<string, Airline>();
            BoardingGates = new Dictionary<string, BoardingGate>();
            Flights = new Dictionary<string, Flight>();
        }

        // Add an airline to the terminal
        public void AddAirline(Airline airline)
        {
            if (!Airlines.ContainsKey(airline.Code))
            {
                Airlines.Add(airline.Code, airline);
            }
        }

        // Add a boarding gate to the terminal
        public void AddBoardingGate(BoardingGate gate)
        {
            if (!BoardingGates.ContainsKey(gate.GateName))
            {
                BoardingGates.Add(gate.GateName, gate);
            }
        }

        // Add a flight to the terminal
        public void AddFlight(Flight flight)
        {
            if (!Flights.ContainsKey(flight.FlightNumber))
            {
                Flights.Add(flight.FlightNumber, flight);

                // Associate the flight with its airline
                if (Airlines.ContainsKey(flight.AirlineName))
                {
                    Airlines[flight.AirlineName].Flights[flight.FlightNumber] = flight;
                }
            }
        }

        // Display flights in chronological order
        public void DisplayFlightsInChronologicalOrder()
        {
            Console.WriteLine("=============================================");
            Console.WriteLine($"Flight Schedule for {TerminalName}");
            Console.WriteLine("=============================================");
            Console.WriteLine("Flight Number   Airline Name           Origin                 Destination            Expected Time     Status          Boarding Gate");

            foreach (var flight in Flights.Values.OrderBy(f => f.ExpectedTime))
            {
                string boardingGate = BoardingGates.Values.FirstOrDefault(g => g.FlightNumber == flight.FlightNumber)?.GateName ?? "Unassigned";
                Console.WriteLine($"{flight.FlightNumber,-15} {flight.AirlineName,-20} {flight.Origin,-20} {flight.Destination,-20} {flight.ExpectedTime:g,-20} {flight.Status,-15} {boardingGate}");
            }
        }

        // Modify flight details
        public void ModifyFlightDetails()
        {
            Console.WriteLine("=============================================");
            Console.WriteLine("List of Airlines for Changi Airport Terminal 5");
            Console.WriteLine("=============================================");
            Console.WriteLine("Airline Code    Airline Name");

            foreach (var airline in Airlines.Values)
            {
                Console.WriteLine($"{airline.Code,-15} {airline.Name}");
            }

            Console.Write("\nEnter Airline Code: ");
            string airlineCode = Console.ReadLine()?.Trim().ToUpper();

            if (!Airlines.ContainsKey(airlineCode))
            {
                Console.WriteLine("Invalid Airline Code.");
                return;
            }

            var airline = Airlines[airlineCode];
            Console.WriteLine($"\nList of Flights for {airline.Name}");
            Console.WriteLine("Flight Number   Origin                 Destination            Expected Time");

            foreach (var flight in airline.Flights.Values)
            {
                Console.WriteLine($"{flight.FlightNumber,-15} {flight.Origin,-20} {flight.Destination,-20} {flight.ExpectedTime:g}");
            }

            Console.Write("\nEnter Flight Number to Modify: ");
            string flightNumber = Console.ReadLine()?.Trim();

            if (!airline.Flights.ContainsKey(flightNumber))
            {
                Console.WriteLine("Invalid Flight Number.");
                return;
            }

            var selectedFlight = airline.Flights[flightNumber];

            Console.WriteLine("\nWhat would you like to modify?");
            Console.WriteLine("1. Modify Origin");
            Console.WriteLine("2. Modify Destination");
            Console.WriteLine("3. Modify Expected Time");
            Console.WriteLine("4. Modify Status");
            Console.WriteLine("5. Modify Special Request Code");
            Console.WriteLine("6. Modify Boarding Gate");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter new Origin: ");
                    selectedFlight.Origin = Console.ReadLine();
                    break;
                case "2":
                    Console.Write("Enter new Destination: ");
                    selectedFlight.Destination = Console.ReadLine();
                    break;
                case "3":
                    Console.Write("Enter new Expected Time (dd/MM/yyyy HH:mm): ");
                    if (DateTime.TryParse(Console.ReadLine(), out var newTime))
                        selectedFlight.ExpectedTime = newTime;
                    else
                        Console.WriteLine("Invalid time format.");
                    break;
                case "4":
                    Console.WriteLine("Enter new Status (On Time/Delayed/Boarding): ");
                    selectedFlight.Status = Console.ReadLine();
                    break;
                case "5":
                    Console.WriteLine("Enter new Special Request Code (CFFT/DDJB/LWTT/None): ");
                    selectedFlight.SpecialRequestCode = Console.ReadLine();
                    break;
                case "6":
                    AssignBoardingGate(selectedFlight);
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
            Console.WriteLine("Flight details updated!");
        }

        // Assign a boarding gate to a flight
        private void AssignBoardingGate(Flight flight)
        {
            Console.WriteLine("Available Gates:");
            foreach (var gate in BoardingGates.Values.Where(g => g.FlightNumber == null))
            {
                Console.WriteLine(gate.GateName);
            }

            Console.Write("Enter Gate Name: ");
            string gateName = Console.ReadLine()?.Trim();

            if (!BoardingGates.ContainsKey(gateName))
            {
                Console.WriteLine("Invalid Gate Name.");
                return;
            }

            var gateToAssign = BoardingGates[gateName];
            gateToAssign.FlightNumber = flight.FlightNumber;
            flight.BoardingGateName = gateName;
            Console.WriteLine($"Assigned Gate {gateName} to Flight {flight.FlightNumber}.");
        }

        // List all flights
        public void ListAllFlights()
        {
            Console.WriteLine("=============================================");
            Console.WriteLine($"List of Flights for {TerminalName}");
            Console.WriteLine("=============================================");
            Console.WriteLine("Flight Number   Airline Name           Origin                 Destination            Expected Time");

            foreach (var flight in Flights.Values.OrderBy(f => f.ExpectedTime))
            {
                Console.WriteLine($"{flight.FlightNumber,-15} {flight.AirlineName,-20} {flight.Origin,-20} {flight.Destination,-20} {flight.ExpectedTime:g}");
            }
        }

        // List all boarding gates
        public void ListAllBoardingGates()
        {
            Console.WriteLine("=============================================");
            Console.WriteLine($"List of Boarding Gates for {TerminalName}");
            Console.WriteLine("=============================================");
            Console.WriteLine("Gate Name       DDJB                   CFFT                   LWTT");

            foreach (var gate in BoardingGates.Values)
            {
                Console.WriteLine($"{gate.GateName,-15} {gate.SupportsDDJB,-20} {gate.SupportsCFFT,-20} {gate.SupportsLWTT,-20}");
            }
        }
    }
}
