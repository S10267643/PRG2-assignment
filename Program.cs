using System;
using System.Collections.Generic;

namespace prg2_assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize the terminal
            Terminal terminal = new Terminal();

            // Dictionaries for airlines, boarding gates, and flights
            Dictionary<string, Airline> airlines = new Dictionary<string, Airline>();
            Dictionary<string, BoardingGate> boardingGates = new Dictionary<string, BoardingGate>();
            Dictionary<string, Flight> flights = new Dictionary<string, Flight>();

            // Load data
            Console.WriteLine("Loading Airlines...");
            int airlineCount = DataLoader.LoadAirlines("airlines.csv", airlines);
            Console.WriteLine($"{airlineCount} Airlines Loaded!");

            Console.WriteLine("Loading Boarding Gates...");
            int gateCount = DataLoader.LoadBoardingGates("boardinggates.csv", boardingGates);
            Console.WriteLine($"{gateCount} Boarding Gates Loaded!");

            Console.WriteLine("Loading Flights...");
            int flightCount = DataLoader.LoadFlights("flights.csv", flights);
            Console.WriteLine($"{flightCount} Flights Loaded!");

            // Add data to terminal
            foreach (var airline in airlines.Values)
                terminal.AddAirline(airline);

            foreach (var gate in boardingGates.Values)
                terminal.AddBoardingGate(gate);

            foreach (var flight in flights.Values)
                terminal.AddFlight(flight);

            // Display menu
            while (true)
            {
                Console.WriteLine("\n=============================================");
                Console.WriteLine("Welcome to Changi Airport Terminal 5");
                Console.WriteLine("=============================================");
                Console.WriteLine("1. List All Flights");
                Console.WriteLine("2. List Boarding Gates");
                Console.WriteLine("3. Assign a Boarding Gate to a Flight");
                Console.WriteLine("4. Create Flight");
                Console.WriteLine("5. Display Airline Flights");
                Console.WriteLine("6. Modify Flight Details");
                Console.WriteLine("7. Display Flight Schedule");
                Console.WriteLine("0. Exit");
                Console.Write("\nPlease select your option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                       /* terminal.ListAllFlights(); */
                        break;
                    case "2":
                       /* terminal.ListAllBoardingGates(); */
                        break;
                    case "3":
                        Console.WriteLine("Assign a Boarding Gate to a Flight feature is not implemented in this version.");
                        break;
                    case "4":
                        Console.WriteLine("Create Flight feature is not implemented in this version.");
                        break;
                    case "5":
                        Console.WriteLine("Display Airline Flights feature is not implemented in this version.");
                        break;
                    case "6":
                        terminal.ModifyFlightDetails();
                        break;
                    case "7":
                        terminal.DisplayFlightsInChronologicalOrder();
                        break;
                    case "0":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
