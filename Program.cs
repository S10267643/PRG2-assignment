using prg2_assignment;
using System;
using System.Collections.Generic;

namespace prg2_assignment
{

    
    class Program
    {
        static void Main()
        {
            Dictionary<string, Airline> airlines = new Dictionary<string, Airline>();
            Dictionary<string, BoardingGate> boardingGates = new Dictionary<string, BoardingGate>();
            Dictionary<string, Flight> flights = new Dictionary<string, Flight>();

            // Load Data
            DataLoader.LoadAirlines("airlines.csv", airlines);
            DataLoader.LoadBoardingGates("boardinggates.csv", boardingGates);
            DataLoader.LoadFlights("flights.csv", flights, airlines);

            // Create Terminal
            Terminal terminal = new Terminal();

            foreach (var airline in airlines.Values) terminal.AddAirline(airline);
            foreach (var gate in boardingGates.Values) terminal.AddBoardingGate(gate);
            foreach (var flight in flights.Values) terminal.AddFlight(flight);

            // Main Menu
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n==== AIRPORT TERMINAL MANAGEMENT SYSTEM ====");
                Console.WriteLine("1. Display Airlines");
                Console.WriteLine("2. Display Scheduled Flights (Chronological Order)");
                Console.WriteLine("3. Modify Flight Details");
                // Console.WriteLine("4. Assign Flights to Boarding Gates");  // Not Implemented Yet
                // Console.WriteLine("5. Remove a Flight");  // Not Implemented Yet
                // Console.WriteLine("6. Save & Exit");  // Not Implemented Yet
                Console.WriteLine("7. Exit Without Saving");
                Console.Write("Enter choice: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        terminal.DisplayAirlines();
                        break;
                    case "2":
                        terminal.DisplayScheduledFlights();
                        break;
                    case "3":
                        Console.Write("Enter Flight Number: ");
                        string flightNumber = Console.ReadLine();
                        Console.Write("Enter New Status: ");
                        string newStatus = Console.ReadLine();
                        Console.Write("Enter New Gate (or leave blank to keep the same): ");
                        string newGate = Console.ReadLine();
                        terminal.ModifyFlightDetails(flightNumber, newStatus, newGate);
                        break;
                    // case "4":
                    //     Console.WriteLine("Feature not implemented yet.");
                    //     break;
                    // case "5":
                    //     Console.WriteLine("Feature not implemented yet.");
                    //     break;
                    // case "6":
                    //     Console.WriteLine("Feature not implemented yet.");
                    //     break;
                    case "7":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }

            Console.WriteLine("\nExiting the program. Have a great day!");
        }
    }

}