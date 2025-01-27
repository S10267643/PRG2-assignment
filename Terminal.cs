using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prg2_assignment
{
    public class Terminal
    {
        public string TerminalName { get; set; }
        public Dictionary<string, Airline> Airlines { get; private set; } = new Dictionary<string, Airline>();
        public Dictionary<string, Flight> Flights { get; private set; } = new Dictionary<string, Flight>();
        public Dictionary<string, BoardingGate> BoardingGates { get; private set; } = new Dictionary<string, BoardingGate>();
        public Dictionary<string, double> GateFees { get; private set; } = new Dictionary<string, double>();

        public Terminal(string name)
        {
            TerminalName = name;
        }

        public bool AddAirline(Airline airline)
        {
            if (!Airlines.ContainsKey(airline.Code))
            {
                Airlines.Add(airline.Code, airline);
                return true;
            }
            return false;
        }

        public bool AddBoardingGate(BoardingGate gate)
        {
            if (!BoardingGates.ContainsKey(gate.GateName))
            {
                BoardingGates.Add(gate.GateName, gate);
                return true;
            }
            return false;
        }

        public Airline GetAirlineFromFlight(Flight flight)
        {
            return Airlines.ContainsKey(flight.AirlineName) ? Airlines[flight.AirlineName] : null;
        }


        public override string ToString()
        {
            return $"Terminal {TerminalName} hosts {Airlines.Count} airlines.";
        }

        public void PrintAirlineFees()
        {
            foreach (var airline in Airlines)
            {
                double totalFees = 0;
                int countFlights = airline.Value.Flights.Count;

                foreach (var flight in airline.Value.Flights.Values)
                {
                    totalFees += flight.CalculateFees();
                }

                // Applying promotions
                double discount = 0;
                discount += (countFlights / 3) * 350; // $350 discount for every 3 flights
                foreach (var flight in airline.Value.Flights.Values)
                {
                    if (flight.ExpectedTime.Hour < 11 || flight.ExpectedTime.Hour > 21)
                        discount += 110; // Early or late flight discount
                    if (flight.Origin == "DXB" || flight.Origin == "BKK" || flight.Origin == "NRT")
                        discount += 25; // Specific origin discount
                    if (string.IsNullOrEmpty(flight.Status)) // Assuming no special request is marked by empty status
                        discount += 50;
                }
                if (countFlights > 5)
                    discount += totalFees * 0.03; // 3% off the total bill for more than 5 flights

                Console.WriteLine($"{airline.Key} owes: {totalFees - discount} in fees after discounts.");
            }
        }

    }

}
