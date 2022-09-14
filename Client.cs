namespace ConsoleBank_CSharp;

public class Client
{
    private int _id;
    private string _name;
    private DateTime _date;

    public Client(int id, string name, DateTime date)
    {
        _id = id;
        _name = name;
        _date = date;
    }

    public int Id
    {
        get => _id;
        set => _id = value;
    }

    public string Name
    {
        get => _name;
        set => _name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public DateTime Date
    {
        get => _date;
        set => _date = value;
    }
}