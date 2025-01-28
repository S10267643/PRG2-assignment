using prg2_assignment;
using System;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;

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
                Console.WriteLine("=============================================");
                Console.WriteLine("Welcome to Changi Airport Terminal 5");
                Console.WriteLine("=============================================");
                Console.WriteLine("1.List All Flights");
                Console.WriteLine("2.List Boarding Gates");
                Console.WriteLine("3.Assign a Boarding Gate to a Flight");
                Console.WriteLine("4.Create Flight");
                Console.WriteLine("5.Display Airline Flights");
                Console.WriteLine("6.Modify Flight Details");
                Console.WriteLine("7.Display Flight Schedule");
                Console.WriteLine("0.Exit");
                Console.WriteLine("Please select your option:");


                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                      //ListFlights();
                        break;
                    case "2":
                      //ListBoardingGates();
                        break;
                    case "3":
                        //assign that shit 
                    case "4":
                         //create dat flight
                     case "5":
                        //DisplayAirlinFlights();
                        break;
                     case "6":
                         // ModifyFlightDetails();
                       break;
                    case "7":
                        //DisplayFlightSchedule();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        Main();
                        break;
                }
            }

            Console.WriteLine("\nExiting the program. Have a great day!");
        }
    }

}