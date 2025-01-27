using System.Collections.Generic;

namespace prg2_assignment
{
    public class Airline
    {
        public string Name { get; private set; }
        public string Code { get; private set; }
        public Dictionary<string, Flight> Flights { get; private set; }

        public Airline(string code, string name)
        {
            Code = code;
            Name = name;
            Flights = new Dictionary<string, Flight>();
        }
    }
}
