

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
        }
    }
}
