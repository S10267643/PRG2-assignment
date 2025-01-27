using System;
using System.Collections.Generic;
using System.IO;

namespace prg2_assignment
{
    public class DataLoader
    {
        public static void LoadAirlines(string filepath, Dictionary<string, Airline> airlines)
        {
            try
            {
                using (var reader = new StreamReader(filepath))
                {
                    // Skip the header row
                    reader.ReadLine();
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (string.IsNullOrWhiteSpace(line)) continue;

                        var values = line.Split(',');

                        // Validate column count
                        if (values.Length >= 2)
                        {
                            var airlineCode = values[1].Trim();
                            var airlineName = values[0].Trim();
                            if (!airlines.ContainsKey(airlineCode))
                            {
                                airlines.Add(airlineCode, new Airline(airlineCode, airlineName));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading airlines: {ex.Message}");
            }
        }

        public static void LoadBoardingGates(string filepath, Dictionary<string, BoardingGate> gates)
        {
            try
            {
                using (var reader = new StreamReader(filepath))
                {
                    // Skip the header row
                    reader.ReadLine();
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (string.IsNullOrWhiteSpace(line)) continue;

                        var values = line.Split(',');

                        // Validate column count
                        if (values.Length >= 4)
                        {
                            var gateName = values[0].Trim();
                            var supportsDDJB = bool.TryParse(values[1].Trim(), out var ddjb) && ddjb;
                            var supportsCFFT = bool.TryParse(values[2].Trim(), out var cfft) && cfft;
                            var supportsLWTT = bool.TryParse(values[3].Trim(), out var lwtt) && lwtt;

                            if (!gates.ContainsKey(gateName))
                            {
                                gates.Add(gateName, new BoardingGate(gateName, supportsCFFT, supportsDDJB, supportsLWTT));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading boarding gates: {ex.Message}");
            }
        }

        public static void LoadFlights(string filepath, Dictionary<string, Flight> flights)
        {
            try
            {
                using (var reader = new StreamReader(filepath))
                {
                    // Skip the header row
                    reader.ReadLine();
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (string.IsNullOrWhiteSpace(line)) continue;

                        var values = line.Split(',');

                        // Validate column count
                        if (values.Length >= 5)
                        {
                            var flightNumber = values[0].Trim();
                            var origin = values[1].Trim();
                            var destination = values[2].Trim();
                            var expectedTime = DateTime.TryParse(values[3].Trim(), out var time) ? time : default;
                            var specialRequest = values[4].Trim();

                            Flight flight;
                            switch (specialRequest)
                            {
                                case "CFFT":
                                    flight = new CFFTFlight(flightNumber, origin, destination, expectedTime, "On Time", "");
                                    break;
                                case "DDJB":
                                    flight = new DDJBFlight(flightNumber, origin, destination, expectedTime, "On Time", "");
                                    break;
                                case "LWTT":
                                    flight = new LWTTFlight(flightNumber, origin, destination, expectedTime, "On Time", "");
                                    break;
                                default:
                                    flight = new LWTTFlight(flightNumber, origin, destination, expectedTime, "On Time", "");
                                    break;
                            }

                            if (!flights.ContainsKey(flightNumber))
                            {
                                flights.Add(flightNumber, flight);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading flights: {ex.Message}");
            }
        }
    }
}

