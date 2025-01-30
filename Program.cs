using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Terminal terminal = new Terminal();
        DataLoader dataLoader = new DataLoader();
        dataLoader.LoadData();

        // Populate Terminal with loaded data
        foreach (var airline in dataLoader.Airlines.Values)
            terminal.AddAirline(airline);
        foreach (var gate in dataLoader.BoardingGates.Values)
            terminal.AddBoardingGate(gate);
        foreach (var flight in dataLoader.Flights.Values)
            terminal.AddFlight(flight);

        while (true)
        {

            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine(" Welcome to Changi Airport Terminal 5 ");
            Console.WriteLine("========================================");
            Console.WriteLine("1. List all flights");
            Console.WriteLine("2. List all boarding gates");
            Console.WriteLine("3. Assign a boarding gate");
            Console.WriteLine("4. Create a new flight");
            Console.WriteLine("5. Display Airline Flights");
            Console.WriteLine("6. Modify Flight Details");
            Console.WriteLine("7. Display Flight Schedule");
            Console.WriteLine("0. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();
            Console.Clear();

            switch (choice)
            {
                case "1":
                    terminal.ListFlights();
                    break;
                case "2":
                    terminal.ListBoardingGates();
                    break;
                case "3":
                    terminal.AssignBoardingGate();
                    break;
                case "4":
                    CreateFlight(terminal, dataLoader.Airlines);
                    break;
                case "5":

                    break;
                case "6":

                    break;
                case "7":

                    break;
                case "0":
                    Console.WriteLine("Exiting system...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }

    static void CreateFlight(Terminal terminal, Dictionary<string, Airline> airlines)
    {
        Console.Write("Enter Flight Number: ");
        string flightNumber = Console.ReadLine();

        Console.Write("Enter Airline Code: ");
        string airlineCode = Console.ReadLine();
        if (!airlines.ContainsKey(airlineCode))
        {
            Console.WriteLine("Invalid airline code.");
            return;
        }

        Console.Write("Enter Origin: ");
        string origin = Console.ReadLine();

        Console.Write("Enter Destination: ");
        string destination = Console.ReadLine();

        Console.Write("Enter Expected Time (yyyy-MM-dd HH:mm): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime expectedTime))
        {
            Console.WriteLine("Invalid date format.");
            return;
        }

        Console.Write("Supports DDJB (true/false): ");
        if (!bool.TryParse(Console.ReadLine(), out bool supportsDDJB))
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        Console.Write("Supports CFFT (true/false): ");
        if (!bool.TryParse(Console.ReadLine(), out bool supportsCFFT))
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        Flight newFlight = new LWTTFlight(flightNumber, airlines[airlineCode], origin, destination, expectedTime, supportsDDJB, supportsCFFT);
        terminal.AddFlight(newFlight);

        Console.WriteLine("\nFlight added successfully!");
    }
}



