namespace prg2_assignment
{
    public class BoardingGate
    {
     
       
            public string GateName { get; private set; }
            public bool SupportsCFFT { get; private set; }
            public bool SupportsDDJB { get; private set; }
            public bool SupportsLWTT { get; private set; }
            public string FlightNumber { get; set; } // New property to track assigned flight

            public BoardingGate(string gateName, bool supportsCFFT, bool supportsDDJB, bool supportsLWTT)
            {
                GateName = gateName;
                SupportsCFFT = supportsCFFT;
                SupportsDDJB = supportsDDJB;
                SupportsLWTT = supportsLWTT;
                FlightNumber = null; // Default value (unassigned)
            }
        

    }
}
