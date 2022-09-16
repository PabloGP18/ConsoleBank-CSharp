using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleBank_CSharp;

public class Bank
{
    private  BankAccount? _bankAccount;
    
    public BankAccount? BankAccount
    {
        get => _bankAccount;
        set => _bankAccount = value;
    }
    
    public  void Registration()
    {
        Console.WriteLine("What is your first and last name?");
        string name = Console.ReadLine();
        Random rnd = new Random();
        int random = rnd.Next(1, 1000);

        BankAccount = 
            new BankAccount(new Client(random,$"{name}",DateTime.Now),0 , "");
        
        
        Console.WriteLine("Your client name is " + _bankAccount.Client.Name + " With client number " + _bankAccount.Client.Id);
    }


    public void Account()
    {
        Console.WriteLine("What kind of bank account are you interested in " + _bankAccount.Client.Name + "?");
        Console.WriteLine("press 1 for a normal account, 2 for a salary account and 3 for a savings account.");
        int account = Int32.Parse(Console.ReadLine());

        switch (account)
        {
            case 1: _bankAccount.Type = "1. normal account";
                break;
            case 2: _bankAccount.Type = "2. salary account";
                break;
            case 3: _bankAccount.Type = "3. savings account";
                break;
        }
        Console.WriteLine("You chose for: " + _bankAccount.Type);
        Console.WriteLine("To make your account active you need to deposit!");
        Console.WriteLine("How much do you want to deposit?");
        int balance = Int32.Parse(Console.ReadLine());
        _bankAccount.Balance = balance;
        Console.WriteLine("You have successfully deposit " + _bankAccount.Balance + "$");
        
        Handler();
    }

    public void Withdraw()
    {
        Console.WriteLine("You want to withdraw your money?");
        int withdraw = Int32.Parse(Console.ReadLine());
        _bankAccount.Balance -= withdraw;
        Console.WriteLine("Your balance is now " + _bankAccount.Balance);
        Handler();

    }

    public void Deposit()
    {
        Console.WriteLine("You want to deposit money?");
        int deposit = Int32.Parse(Console.ReadLine());
        _bankAccount.Balance += deposit;
        Console.WriteLine("Your balance is now " + _bankAccount.Balance);
        Handler();
    }

    public void Handler()
    {
        Console.WriteLine("What do you want to do?");
        int option = Int32.Parse(Console.ReadLine());
        Console.WriteLine("you chose" + option);

        switch (option)
        {
            case 1: Registration();
                Console.WriteLine("You want to make a registration.");
                break;
            case 2: Account();
                Console.WriteLine("You want to choose your " + _bankAccount.Type + ".");
                break;
            case 3: Withdraw();
                break;
            case 4: Deposit();
                break;
        }
    }
}