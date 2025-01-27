using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prg2_assignment
{
    public class BoardingGate
    {
        public string GateName { get; private set; }
        public bool SupportsCFFT { get; private set; }
        public bool SupportsDDJB { get; private set; }
        public bool SupportsLWTT { get; private set; }
        public Flight AssignedFlight { get; set; }

        public BoardingGate(string gateName, bool supportsCFFT, bool supportsDDJB, bool supportsLWTT)
        {
            GateName = gateName;
            SupportsCFFT = supportsCFFT;
            SupportsDDJB = supportsDDJB;
            SupportsLWTT = supportsLWTT;
        }

        public double CalculateFees()
        {
            double fee = 300; // Base fee
            if (SupportsCFFT) fee += 150;
            if (SupportsDDJB) fee += 300;
            if (SupportsLWTT) fee += 500;
            return fee;
        }

        public override string ToString()
        {
            return $"{GateName} supports CFFT: {SupportsCFFT}, DDJB: {SupportsDDJB}, LWTT: {SupportsLWTT}";
        }
    }
}
