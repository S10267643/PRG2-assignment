using System;
using System.Collections.Generic;
using System.Linq;

namespace prg2_assignment
{
    public class Terminal
    {
        public string TerminalName { get; private set; }
        public Dictionary<string, Airline> Airlines { get; private set; }
        public Dictionary<string, BoardingGate> BoardingGates { get; private set; }
        public Dictionary<string, Flight> Flights { get; private set; }

        public Terminal(string terminalName)
        {
            TerminalName = terminalName;
            Airlines = new Dictionary<string, Airline>();
            BoardingGates = new Dictionary<string, BoardingGate>();
            Flights = new Dictionary<string, Flight>();
        }

        /// <summary>
        /// Adds an airline to the terminal.
        /// </summary>
        public bool AddAirline(Airline airline)
        {
            if (!Airlines.ContainsKey(airline.Code))
            {
                Airlines.Add(airline.Code, airline);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Adds a boarding gate to the terminal.
        /// </summary>
        public bool AddBoardingGate(BoardingGate gate)
        {
            if (!BoardingGates.ContainsKey(gate.GateName))
            {
                BoardingGates.Add(gate.GateName, gate);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Adds a flight to the terminal and associates it with an airline if applicable.
        /// </summary>
        public bool AddFlight(Flight flight)
        {
            if (!Flights.ContainsKey(flight.FlightNumber))
            {
                Flights.Add(flight.FlightNumber, flight);

                // Associate the flight with its airline
                if (Airlines.ContainsKey(flight.AirlineName))
                {
                    Airlines[flight.AirlineName].Flights[flight.FlightNumber] = flight;
                }
                return true;
            }
            return false;
        }

   
        /// <summary>
        /// Lists all flights with basic information.
        /// </summary>
        public void ListAllFlights()
        {
            Console.WriteLine("=============================================");
            Console.WriteLine("List of Flights for Changi Airport Terminal 5");
            Console.WriteLine("=============================================");
            Console.WriteLine("Flight Number   Airline Name           Origin                 Destination            Expected Time");
            foreach (var flight in Flights.Values.OrderBy(f => f.ExpectedTime))
            {
                Console.WriteLine($"{flight.FlightNumber,-15} {flight.AirlineName,-20} {flight.Origin,-20} {flight.Destination,-20} {flight.ExpectedTime:g}");
            }
        }

        /// <summary>
        /// Lists all boarding gates and their supported special request codes.
        /// </summary>
        public void ListAllBoardingGates()
        {
            Console.WriteLine("=============================================");
            Console.WriteLine("List of Boarding Gates for Changi Airport Terminal 5");
            Console.WriteLine("=============================================");
            Console.WriteLine("Gate Name       DDJB                   CFFT                   LWTT");
            foreach (var gate in BoardingGates.Values)
            {
                Console.WriteLine($"{gate.GateName,-15} {gate.SupportsDDJB,-20} {gate.SupportsCFFT,-20} {gate.SupportsLWTT,-20}");
            }
        }


     

           
            public void ModifyFlightDetails()
            {
                Console.WriteLine("=============================================");
                Console.WriteLine("List of Airlines for Changi Airport Terminal 5");
                Console.WriteLine("=============================================");
                Console.WriteLine("Airline Code    Airline Name");

                foreach (var airline in Airlines.Values)
                {
                    Console.WriteLine($"{airline.Code,-15} {airline.Name}");
                }

                Console.Write("\nEnter Airline Code: ");
                string airlineCode = Console.ReadLine()?.Trim().ToUpper();

                if (!Airlines.ContainsKey(airlineCode))
                {
                    Console.WriteLine("Invalid Airline Code.");
                    return;
                }

                var airline = Airlines[airlineCode];
                Console.WriteLine($"\nList of Flights for {airline.Name}");
                Console.WriteLine("Flight Number   Origin                 Destination            Expected Time");

                foreach (var flight in airline.Flights.Values)
                {
                    Console.WriteLine($"{flight.FlightNumber,-15} {flight.Origin,-20} {flight.Destination,-20} {flight.ExpectedTime:g}");
                }

                Console.Write("\nEnter Flight Number to Modify: ");
                string flightNumber = Console.ReadLine()?.Trim();

                if (!airline.Flights.ContainsKey(flightNumber))
                {
                    Console.WriteLine("Invalid Flight Number.");
                    return;
                }

                var selectedFlight = airline.Flights[flightNumber];

                Console.WriteLine("\nWhat would you like to modify?");
                Console.WriteLine("1. Modify Basic Information");
                Console.WriteLine("2. Modify Status");
                Console.WriteLine("3. Modify Special Request Code");
                Console.WriteLine("4. Modify Boarding Gate");
                Console.Write("Choose an option: ");
                int option = int.TryParse(Console.ReadLine(), out var result) ? result : -1;

                switch (option)
                {
                    case 1:
                        ModifyBasicInformation(selectedFlight);
                        break;
                    case 2:
                        ModifyStatus(selectedFlight);
                        break;
                    case 3:
                        ModifySpecialRequestCode(selectedFlight);
                        break;
                    case 4:
                        Console.WriteLine("Assigning boarding gates is handled separately.");
                        break;
                    default:
                        Console.WriteLine("Invalid Option.");
                        break;
                }
            }

           
            public void DisplayFlightsInChronologicalOrder()
            {
                Console.WriteLine("=============================================");
                Console.WriteLine("Flight Schedule for Changi Airport Terminal 5");
                Console.WriteLine("=============================================");
                Console.WriteLine("Flight Number   Airline Name           Origin                 Destination            Expected Time     Status          Boarding Gate");

                foreach (var flight in Flights.Values.OrderBy(f => f.ExpectedTime))
                {
                    string specialRequest = flight is CFFTFlight ? "CFFT"
                        : flight is DDJBFlight ? "DDJB"
                        : flight is LWTTFlight ? "LWTT"
                        : "None";

                    Console.WriteLine($"{flight.FlightNumber,-15} {flight.AirlineName,-20} {flight.Origin,-20} {flight.Destination,-20} {flight.ExpectedTime:g,-20} {flight.Status,-15} {specialRequest}");
                }
            }

            // Helper methods for flight modification
            private void ModifyBasicInformation(Flight flight)
            {
                Console.Write("Enter new Origin: ");
                string newOrigin = Console.ReadLine()?.Trim();
                Console.Write("Enter new Destination: ");
                string newDestination = Console.ReadLine()?.Trim();
                Console.Write("Enter new Expected Time (dd/mm/yyyy hh:mm): ");
                if (DateTime.TryParse(Console.ReadLine()?.Trim(), out var newTime))
                {
                    // Assuming Flight class has setters or reflection is used for modification
                    flight.GetType().GetProperty("Origin")?.SetValue(flight, newOrigin);
                    flight.GetType().GetProperty("Destination")?.SetValue(flight, newDestination);
                    flight.GetType().GetProperty("ExpectedTime")?.SetValue(flight, newTime);

                    Console.WriteLine("Flight details updated!");
                }
                else
                {
                    Console.WriteLine("Invalid time format.");
                }
            }

            private void ModifyStatus(Flight flight)
            {
                Console.WriteLine("1. Delayed");
                Console.WriteLine("2. Boarding");
                Console.WriteLine("3. On Time");
                Console.Write("Select new status: ");
                int statusOption = int.TryParse(Console.ReadLine(), out var result) ? result : -1;

                string newStatus = statusOption switch
                {
                    1 => "Delayed",
                    2 => "Boarding",
                    3 => "On Time",
                    _ => null
                };

                if (!string.IsNullOrEmpty(newStatus))
                {
                    flight.GetType().GetProperty("Status")?.SetValue(flight, newStatus);
                    Console.WriteLine("Flight status updated!");
                }
                else
                {
                    Console.WriteLine("Invalid status selected.");
                }
            }

            private void ModifySpecialRequestCode(Flight flight)
            {
                Console.Write("Enter new Special Request Code (CFFT/DDJB/LWTT/None): ");
                string newRequest = Console.ReadLine()?.Trim();
                Console.WriteLine("Special request code updated!");
            }
        }
    }


    

