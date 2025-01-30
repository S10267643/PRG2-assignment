class BoardingGate
{
    public string GateName { get; set; }
    public bool supportsCFFT{ get; set; }
    public bool supportsDDJB { get; set; }
    public bool supportsLWTT { get; set; }


    public BoardingGate(string gateName,bool SupportsCFFT, bool SupportsDDJB, bool SupportsLWTT)
    {
        GateName = gateName;
        supportsCFFT = SupportsCFFT;
        supportsDDJB = SupportsDDJB;
        supportsLWTT = SupportsLWTT;
    }

    public override string ToString()
    {
        return $"{GateName} -";
    }
   /* public double CalculateFees()
    {

        return;
    }*/
}
