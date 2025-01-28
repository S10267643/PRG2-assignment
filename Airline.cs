public class Airline
{
    public string Code { get; private set; }
    public string Name { get; private set; }

    public Airline(string code, string name)
    {
        Code = code;
        Name = name;
    }
    
}
