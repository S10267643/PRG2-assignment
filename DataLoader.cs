using System;
using System.Collections.Generic;
using System.IO;

namespace prg2_assignment
{
    public class DataLoader
    {
        public static void LoadAirlines(string filepath, Dictionary<string, Airline> airlines)
        {
            Console.WriteLine("Loading Airlines...");
            int count = 0;
            try
            {
                using (var reader = new StreamReader(filepath))
                {
                    reader.ReadLine(); // Skip header row
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (string.IsNullOrWhiteSpace(line)) continue;

                        var values = line.Split(',');
                        if (values.Length >= 2)
                        {
                            var airlineCode = values[1].Trim();
                            var airlineName = values[0].Trim();
                            if (!airlines.ContainsKey(airlineCode))
                            {
                                airlines.Add(airlineCode, new Airline(airlineCode, airlineName));
                                count++;
                            }
                        }
                    }
                }
                Console.WriteLine($"{count} Airlines Loaded!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading airlines: {ex.Message}");
            }
        }

        public static void LoadBoardingGates(string filepath, Dictionary<string, BoardingGate> gates)
        {
            Console.WriteLine("Loading Boarding Gates...");
            int count = 0;
            try
            {
                using (var reader = new StreamReader(filepath))
                {
                    reader.ReadLine(); // Skip header row
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (string.IsNullOrWhiteSpace(line)) continue;

                        var values = line.Split(',');
                        if (values.Length >= 4)
                        {
                            var gateName = values[0].Trim();
                            var supportsDDJB = bool.TryParse(values[1].Trim(), out var ddjb) && ddjb;
                            var supportsCFFT = bool.TryParse(values[2].Trim(), out var cfft) && cfft;
                            var supportsLWTT = bool.TryParse(values[3].Trim(), out var lwtt) && lwtt;

                            if (!gates.ContainsKey(gateName))
                            {
                                gates.Add(gateName, new BoardingGate(gateName, supportsCFFT, supportsDDJB, supportsLWTT));
                                count++;
                            }
                        }
                    }
                }
                Console.WriteLine($"{count} Boarding Gates Loaded!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading boarding gates: {ex.Message}");
            }
        }

        public static void LoadFlights(string filepath, Dictionary<string, Flight> flights)
        {
            Console.WriteLine("Loading Flights...");
            int count = 0;
            try
            {
                using (var reader = new StreamReader(filepath))
                {
                    reader.ReadLine(); // Skip header row
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (string.IsNullOrWhiteSpace(line)) continue;

                        var values = line.Split(',');
                        if (values.Length >= 5)
                        {
                            var flightNumber = values[0].Trim();
                            var origin = values[1].Trim();
                            var destination = values[2].Trim();
                            var expectedTime = DateTime.TryParse(values[3].Trim(), out var time) ? time : default;
                            var specialRequest = values[4].Trim();

                            // Instantiate the appropriate subclass based on the special request
                            Flight flight = specialRequest switch
                            {
                                "CFFT" => new CFFTFlight(flightNumber, origin, destination, time, "On Time", ""),
                                "DDJB" => new DDJBFlight(flightNumber, origin, destination, time, "On Time", ""),
                                "LWTT" => new LWTTFlight(flightNumber, origin, destination, time, "On Time", ""),
                                _ => null // Skip invalid special request codes
                            };

                            if (flight != null && !flights.ContainsKey(flightNumber))
                            {
                                flights.Add(flightNumber, flight);
                                count++;
                            }
                        }
                    }
                }
                Console.WriteLine($"{count} Flights Loaded!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading flights: {ex.Message}");
            }
        }

    }
}
