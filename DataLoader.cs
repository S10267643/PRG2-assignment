using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prg2_assignment
{
    public class DataLoader
    {
        public static void LoadAirlines(string filepath, Dictionary<string, Airline> airlines)
        {
            using (var reader = new StreamReader(filepath))
            {
                reader.ReadLine(); // Assuming the first line is headers
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    var airline = new Airline(values[0], values[1]);
                    airlines.Add(airline.Code, airline);
                }
            }
        }

        public static void LoadBoardingGates(string filepath, Dictionary<string, BoardingGate> gates)
        {
            using (var reader = new StreamReader(filepath))
            {
                reader.ReadLine(); // Assuming the first line is headers
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    var gate = new BoardingGate(values[0], bool.Parse(values[1]), bool.Parse(values[2]), bool.Parse(values[3]));
                    gates.Add(gate.GateName, gate);
                }
            }
        }

        public static void LoadFlights(string filepath, Dictionary<string, Flight> flights)
        {
            using (var reader = new StreamReader(filepath))
            {
                reader.ReadLine(); // Assuming the first line is headers
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    DateTime expectedTime;
                    DateTime.TryParse(values[3], out expectedTime);
                    var flight = new Flight(values[0], values[1], values[2], expectedTime, values[4]);
                    flights.Add(flight.FlightNumber, flight);
                }
            }
        }
    }
}
