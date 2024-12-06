using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MainProject;

class Transaction
{
        private global::System.String description;
        private global::System.String month;

        public string Description { get => description; set => description = value; }
        public string Month  { get => month; set => month = value; }
        public float Amount { get; set; }
        public int Id { get; set; }
    }

class MoneyTracker
{
    List<Transaction> transactions = new List<Transaction>();
    const string SaveFileName = "trackmoney.txt";

    public void executeAccountOperations()
    {
        LoadData();

        while (true)
        {
            Console.Clear();
            float balance = transactions.Sum(t => t.Amount);
            Console.WriteLine("Welcome to Trackmoney");
            Console.WriteLine($"You have currently {balance}kr in your account\n");

            Console.WriteLine("Pick an option:");
            Console.WriteLine("(1) Show items (All / Expense(s) / Income(s))");
            Console.WriteLine("(2) Add new expense / income");
            Console.WriteLine("(3) Edit Item (Edit / Remove)");
            Console.WriteLine("(4) Save and Quit");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ShowItems();
                    break;
                case "2":
                    AddItem();
                    break;
                case "3":
                    EditOrRemoveItem();
                    break;
                case "4":
                    SaveAndQuit();
                    break;
                default:
                    Console.WriteLine("Invalid option. Press any key to try again...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void ShowItems()
    {

    }
    private void AddItem()
    {

    }

    private void EditOrRemoveItem()
    {
        Console.WriteLine("\nCurrent Items:");
        foreach (var transaction in transactions)
        {
            Console.WriteLine($"{transaction.Id}. {transaction.Description} | {transaction.Amount:C} | {transaction.Month}");
        }

        Console.Write("\nEnter the ID of the item to edit or remove: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID. Press any key to return...");
            Console.ReadKey();
            return;
        }

        var item = transactions.FirstOrDefault(t => t.Id == id);
        if (item == null)
        {
            Console.WriteLine("Item not found. Press any key to return...");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("(1) Edit, (2) Remove");
        string action = Console.ReadLine();

        if (action == "1")
        {
            Console.Write("Enter new description: ");
            item.Description = Console.ReadLine();

            Console.Write("Enter new amount: ");
            if (float.TryParse(Console.ReadLine(), out float newAmount))
                item.Amount = newAmount;

            Console.Write("Enter new month: ");
            item.Month = Console.ReadLine();

            Console.WriteLine("Item updated successfully. Press any key to return...");
        }
        else if (action == "2")
        {
            transactions.Remove(item);
            Console.WriteLine("Item removed successfully. Press any key to return...");
        }
        else
        {
            Console.WriteLine("Invalid action. Press any key to return...");
        }

        Console.ReadKey();
    }

    private void SaveAndQuit()
    {
        Console.WriteLine("Data saved. Goodbye!");
    }

    private void LoadData()
    {
        FileHandling fileHandling = new FileHandling(SaveFileName);
        List<string> lines = fileHandling.LoadData();

        foreach (string line in lines)
        {
            var parts = line.Split('|');
            lines.Add(line);
            transactions.Add(new Transaction
            {
                Id = int.Parse(parts[0]),
                Description = parts[1],
                Amount = float.Parse(parts[2]),
                Month = parts[3]
            });
        }
    }
}
