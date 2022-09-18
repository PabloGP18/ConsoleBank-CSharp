using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleBank_CSharp;

public class Bank
{
    private  BankAccount? _bankAccount { get; set; }
    private string? _bankName { get; set; }

    public Bank(string? bankName)
    {
        _bankName = bankName;
    }
    
    private void Greeting()
    {
        Console.WriteLine($"Hello, welcome to {_bankName}");
    }

    private void Exit()
    {
        Console.WriteLine("Bye bye and thank you for choosing " + _bankName + "!");
    }
    public  void Registration()
    {
        Greeting();
        
        Console.WriteLine("Are you already a customer to the " + _bankName + "? (y/n)");
        string? response = Console.ReadLine();
        string? confirmation = response.ToLower();
        bool checkInput = false;

        do
        {
            if (confirmation == "y" || confirmation == "yes")
            {
                checkInput = true;
                Console.WriteLine("What is your first and last name?");
                string name = Console.ReadLine();
                Random rnd = new Random();
                int random = rnd.Next(1, 1000);
                int balance = 10000;

                _bankAccount = 
                    new BankAccount(new Client(random,name,DateTime.Now),balance, String.Empty);
                
                Console.WriteLine("Your client name is " + _bankAccount.Client.Name + " With client number " + _bankAccount.Client.Id);
            }
            else if (confirmation == "n" || confirmation == "no")
            {
                checkInput = true;
                Console.WriteLine("Welcome new customer to " + _bankName +".");
                Console.WriteLine("Can you insert your name?");
                Console.WriteLine("Name: ");
                string? name = Console.ReadLine();
                Random rnd = new Random();
                int random = rnd.Next(1, 1000);
                int balance = 1000;

            
                _bankAccount = 
                    new BankAccount(new Client(random, name, DateTime.Now), balance, String.Empty);
            }else
                Console.WriteLine("you have yo pick yes or no!");
            
        } while (!checkInput);
        
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
        Console.WriteLine("Do you want to deposit? (y/n)");
        string? response = Console.ReadLine();

        if (response == "y")
        {
            Console.WriteLine("How much do you want to deposit?");
            int balance = Int32.Parse(Console.ReadLine());
            _bankAccount.Balance = balance;
            Console.WriteLine("You have successfully deposit " + _bankAccount.Balance + "$");
        }
        else
        {
            Console.WriteLine("Ok, no problem!");
        }
        
        Handler();
    }

    public void Withdraw()
    {
        Console.WriteLine("How much do you want to withdraw?");
        int withdraw = Int32.Parse(Console.ReadLine());

        while (withdraw > _bankAccount.Balance)
        {
            Console.WriteLine("Your balance can not go below zero! Try again please.");
            withdraw = Int32.Parse(Console.ReadLine());
        }
        
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
        Console.WriteLine("Tell me what do you want to do?\n Choose number 1 to check your account type. \n Choose number 2 to withdraw money from your account.  \n" +
                          "Choose number 3 to deposit money to your account. \n Choose number 4 to exit the application.");
        int option = Int32.Parse(Console.ReadLine());
        Console.WriteLine("you chose " + option);

        switch (option)
        {
            case 1: Account();
                break;
            case 2: Withdraw();
                break;
            case 3: Deposit();
                break;
            case 4: Exit();
                break;
        }
    }
}