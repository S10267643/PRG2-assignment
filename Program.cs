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
                Console.WriteLine("\n1. Display Airlines");
                Console.WriteLine("2. Display Scheduled Flights");
                Console.WriteLine("3. Modify Flight Details");
                Console.WriteLine("4. Exit");
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
                        Console.Write("Enter New Gate: ");
                        string newGate = Console.ReadLine();
                        terminal.ModifyFlightDetails(flightNumber, newStatus, newGate);
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }
    }
}