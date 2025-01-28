using System;
using System.Collections.Generic;
using System.IO;

namespace prg2_assignment
{
    public static class DataLoader
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
                        var values = line.Split(',');
                        if (values.Length >= 2)
                        {
                            string code = values[1].Trim();
                            string name = values[0].Trim();
                            if (!airlines.ContainsKey(code))
                            {
                                airlines.Add(code, new Airline(code, name));
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
                        var values = line.Split(',');
                        if (values.Length >= 4)
                        {
                            string gateName = values[0].Trim();
                            bool supportsDDJB = bool.Parse(values[1].Trim());
                            bool supportsCFFT = bool.Parse(values[2].Trim());
                            bool supportsLWTT = bool.Parse(values[3].Trim());

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
                        var values = line.Split(',');
                        if (values.Length >= 5)
                        {
                            string flightNumber = values[0].Trim();
                            string origin = values[1].Trim();
                            string destination = values[2].Trim();
                            DateTime expectedTime = DateTime.Parse(values[3].Trim());
                            string specialRequestCode = values[4].Trim();

                            Flight flight = specialRequestCode switch
                            {
                                "CFFT" => new CFFTFlight(flightNumber, origin, destination, expectedTime, "On Time", ""),
                                "DDJB" => new DDJBFlight(flightNumber, origin, destination, expectedTime, "On Time", ""),
                                "LWTT" => new LWTTFlight(flightNumber, origin, destination, expectedTime, "On Time", ""),
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
