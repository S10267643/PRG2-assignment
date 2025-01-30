class BoardingGate
{
    public string GateName { get; set; }
    public bool IsOccupied { get; set; }

    public BoardingGate(string gateName)
    {
        GateName = gateName;
        IsOccupied = false;
    }

    public override string ToString()
    {
        return $"{GateName} - {(IsOccupied ? "Occupied" : "Available")}";
    }
}
