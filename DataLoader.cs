using System;
using System.Collections.Generic;
using System.IO;

namespace prg2_assignment
{
    public class DataLoader
    {
        public static int LoadAirlines(string filepath, Dictionary<string, Airline> airlines)
        {
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
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading airlines: {ex.Message}");
            }
            return count;
        }

        public static int LoadBoardingGates(string filepath, Dictionary<string, BoardingGate> gates)
        {
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
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading boarding gates: {ex.Message}");
            }
            return count;
        }

        public static int LoadFlights(string filepath, Dictionary<string, Flight> flights)
        {
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

                            Flight flight = specialRequest switch
                            {
                                "CFFT" => new CFFTFlight(flightNumber, origin, destination, time, "On Time", ""),
                                "DDJB" => new DDJBFlight(flightNumber, origin, destination, time, "On Time", ""),
                                "LWTT" => new LWTTFlight(flightNumber, origin, destination, time, "On Time", ""),
                                _ => null
                            };

                            if (flight != null && !flights.ContainsKey(flightNumber))
                            {
                                flights.Add(flightNumber, flight);
                                count++;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading flights: {ex.Message}");
            }
            return count;
        }
    }
}
