﻿using System;

class Program
{
    static void Main()
    {
        
        DataLoader dataLoader = new DataLoader();
        dataLoader.LoadData();

        Terminal terminal = new Terminal(dataLoader); 

        
        Console.WriteLine("=============================================");
        Console.WriteLine("Welcome to Changi Airport Terminal 5");
        Console.WriteLine("=============================================");

        while (true)
        {
            Console.WriteLine("\n1. List All Flights");
            Console.WriteLine("2. List Boarding Gates");
            Console.WriteLine("3. Assign a Boarding Gate to a Flight");
            Console.WriteLine("4. Create Flight");
            Console.WriteLine("5. Display Airline Flights");
            Console.WriteLine("6. Modify Flight Details");
            Console.WriteLine("7. Display Flight Schedule");
            Console.WriteLine("0. Exit");
            Console.Write("Please select your option: ");

           
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    terminal.ListAllFlights();  
                    break;
                case "2":
                    terminal.ListBoardingGates();  
                    break;
                case "3":
                  //  terminal.AssignBoardingGate();
                    break;
                case "4":
                    // terminal.CreateFlight(); // 🚧 Not yet implemented
                    break;
                case "5":
                    // terminal.DisplayAirlineFlights(); // 🚧 Not yet implemented
                    break;
                case "6":
                    // terminal.ModifyFlightDetails(); // 🚧 Not yet implemented
                    break;
                case "7":
                    // terminal.DisplayFlightSchedule(); // 🚧 Not yet implemented
                    break;
                case "0":
                    Console.WriteLine("Exiting program...");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    Main();
                    break;
            }
        }
    }
}

