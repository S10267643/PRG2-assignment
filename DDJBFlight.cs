using System;

class DDJBFlight : Flight
{
    public DDJBFlight(string flightNumber, Airline airline, string origin, string destination, DateTime expectedTime)
        : base(flightNumber, airline, origin, destination, expectedTime) { }

    public override double CalculateFees()
    {
        double baseFee = 8000;
        double discount = 0;

        // Promotions based on flight count
        int flightCount = Airline.GetFlightCount();
        discount += (flightCount / 3) * 700; // Every 3 flights -> $700 off

        // Stacking promotions
        if (flightCount >= 10) discount += 500; // Extra $500 off if 10 or more flights
        if (flightCount >= 20) discount += 1000; // Extra $1000 off if 20 or more flights

        double finalFee = baseFee - discount;
        finalFee *= 0.97; // Apply final 3% discount

        return Math.Max(finalFee, 0); // Ensure fee is not negative
    }
}
