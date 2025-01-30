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

    public override double CalculateFees()
    {
        return 5000; 
    }

    public override string ToString()
    {
        return base.ToString() + $" {SupportsDDJB,-10} {SupportsCFFT,-10}";
    }
}
