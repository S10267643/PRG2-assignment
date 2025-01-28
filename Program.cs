

using prg2_assignment;
using System;
using System.Collections.Generic;
using System.IO;


//==========================================================
// Student Number	: S10267904
// Student Name	: amir daiyan
// Partner Name	: ashton leu
//==========================================================








namespace prg2_assignment
{
    class Program
    {
        static void Main()
        {
            var airlines = new Dictionary<string, Airline>();
            var gates = new Dictionary<string, BoardingGate>();
            var flights = new Dictionary<string, Flight>();

            Console.WriteLine("Loading Airlines...");
            int airlineCount = DataLoader.LoadAirlines("airlines.csv", airlines);
            Console.WriteLine($"{airlineCount} Airlines Loaded!");

            Console.WriteLine("Loading Boarding Gates...");
            int gateCount = DataLoader.LoadBoardingGates("boardinggates.csv", gates);
            Console.WriteLine($"{gateCount} Boarding Gates Loaded!");

            Console.WriteLine("Loading Flights...");
            int flightCount = DataLoader.LoadFlights("flights.csv", flights);
            Console.WriteLine($"{flightCount} Flights Loaded!");
        

       


        
        
           

                // Menu
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
                            Terminal.ListAllFlights();
                            break;
                        case "2":
                            Terminal.ListAllBoardingGates();
                            break;
                        case "3":
                            Console.WriteLine("Feature to assign boarding gate not implemented in this menu.");
                            break;
                        case "4":
                            Console.WriteLine("Feature to create flights not implemented in this menu.");
                            break;
                        case "5":
                            Console.WriteLine("Feature to display flights for an airline not implemented in this menu.");
                            break;
                        case "6":
                            Terminal.ModifyFlightDetails();
                            break;
                        case "7":
                            Terminal.DisplayFlightsInChronologicalOrder();
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
