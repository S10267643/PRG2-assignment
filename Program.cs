

using prg2_assignment;
using System;
using System.Collections.Generic;
using System.IO;


//==========================================================
// Student Number	: S10267904
// Student Name	: amir daiyan
// Partner Name	: ashton leu
//==========================================================







class Program
{
    static void Main()
    {
        var airlines = new Dictionary<string, Airline>();
        var gates = new Dictionary<string, BoardingGate>();
        var flights = new Dictionary<string, Flight>();

        int airlinesLoaded = DataLoader.LoadAirlines("airlines.csv", airlines);
        int gatesLoaded = DataLoader.LoadBoardingGates("boardinggates.csv", gates);
        int flightsLoaded = DataLoader.LoadFlights("flights.csv", flights);

        Console.WriteLine("Loading Airlines...");
        Console.WriteLine($"{airlinesLoaded} Airlines Loaded!");

        Console.WriteLine("Loading Boarding Gates...");
        Console.WriteLine($"{gatesLoaded} Boarding Gates Loaded!");

        Console.WriteLine("Loading Flights...");
        Console.WriteLine($"{flightsLoaded} Flights Loaded!");
    }
}
