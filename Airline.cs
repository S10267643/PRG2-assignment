using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prg2_assignment
{
    public class Airline
    {
        public string Name { get; private set; }
        public string Code { get; private set; }
        public Dictionary<string, Flight> Flights { get; private set; } = new Dictionary<string, Flight>();

        public Airline(string code, string name)
        {
            Code = code;
            Name = name;
        }

        public bool AddFlight(Flight flight)
        {
            if (!Flights.ContainsKey(flight.FlightNumber))
            {
                Flights.Add(flight.FlightNumber, flight);
                return true;
            }
            return false;
        }

        public bool RemoveFlight(string flightNumber)
        {
            return Flights.Remove(flightNumber);
        }

        public double CalculateFees()
        {
            double totalFees = 0;
            foreach (var flight in Flights.Values)
            {
                totalFees += flight.CalculateFees();
            }
            return totalFees;
        }

        public override string ToString()
        {
            return $"{Name} ({Code})";
        }
    }
}
