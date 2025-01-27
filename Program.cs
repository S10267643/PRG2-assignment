

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
        DataLoader.LoadAirlines("airlines.csv", airlines);

        var gates = new Dictionary<string, BoardingGate>();
        DataLoader.LoadBoardingGates("boardinggates.csv", gates);

        var flights = new Dictionary<string, Flight>();
        DataLoader.LoadFlights("flights.csv", flights);

        // Display loaded data
        Console.WriteLine("Airlines loaded:");
        foreach (var airline in airlines.Values)
        {
            Console.WriteLine(airline);
        }

        Console.WriteLine("Gates loaded:");
        foreach (var gate in gates.Values)
        {
            Console.WriteLine(gate);
        }

        Console.WriteLine("Flights loaded:");
        foreach (var flight in flights.Values)
        {
            Console.WriteLine(flight);
        }
    }
}

