using System.Reflection.Metadata.Ecma335;

namespace ConsoleBank_CSharp;

public class BankAccount
{
    private Client? _client;
    private int _balance;
    private string? _type;

    public BankAccount(Client? client, int balance, string? type)
    {
        _client = client;
        _balance = balance;
        _type = type;
    }

    public Client? Client
    {
        get => _client;
        set => _client = value;
    }

    public int Balance
    {
        get => _balance;
        set => _balance = value;
    }

    public string? Type
    {
        get => _type;
        set => _type = value;
    }
    
}