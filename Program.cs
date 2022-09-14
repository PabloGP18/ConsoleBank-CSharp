using System.Data;
using System.Runtime.InteropServices;
using ConsoleBank_CSharp;


Client client = new Client(1, "besart", DateTime.Now);
Console.WriteLine("What is your name:");
client.Name= Console.ReadLine();
Console.WriteLine($"Your name is: {client.Name}");
