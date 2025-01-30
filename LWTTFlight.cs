class LWTTFlight : Flight
{
    public bool SupportsDDJB { get; set; }
    public bool SupportsCFFT { get; set; }

    public LWTTFlight(string flightNumber, Airline airline, string origin, string destination, DateTime expectedTime, bool supportsDDJB, bool supportsCFFT)
        : base(flightNumber, airline, origin, destination, expectedTime)
    {
        SupportsDDJB = supportsDDJB;
        SupportsCFFT = supportsCFFT;
    }

    public override decimal CalculateFees()
    {
        return 5000; // Placeholder fee, update based on assignment rules
    }

    public override string ToString()
    {
        return base.ToString() + $" {SupportsDDJB,-10} {SupportsCFFT,-10}";
    }
}
