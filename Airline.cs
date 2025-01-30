class Airline
{
    public string Name { get; set; }
    public string Code { get; set; } // e.g., SQ for Singapore Airlines

    public Airline(string code, string name)
    {
        Code = code;
        Name = name;
    }

    public override string ToString()
    {
        return $"{Code} - {Name}";
    }
}
