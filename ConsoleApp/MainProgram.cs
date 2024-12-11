// See https://aka.ms/new-console-template for more information

using System;
using MoneyTrackingApp;

namespace Assignment
{
  class Program
  {
    static void Main(string[] args)
    {

      while (true)
      {
        Console.Clear();

        Console.WriteLine("Please choose which assignment want to run \n1 - W47 Mini Project \n2 - W48 Mini Project");
        Console.WriteLine("3 - W49 Mini Project");

        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write("A -Money Traker Application  ");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(" (Individual Project - 1) ");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Enter which application to launch or Press Q for quit the application : ");
        Console.ResetColor();

        String strInputValue = Console.ReadLine().Trim().ToUpper();
        switch (strInputValue)
        {
          case "1":
            {
              AssignmentW47 assignementW47 = new AssignmentW47();
              assignementW47.w47tAssignment();
              break;
            }
          case "2":
            {
              AssignmentW48 assignementW48 = new AssignmentW48();
              assignementW48.w48Assignment();
              break;
            }
          case "3":
            {
              AssignmentW49 assignementW49 = new AssignmentW49();
              assignementW49.w49Assignment();
              break;
            }
          case "A":
            {
              MoneyTracker moneyTracker = new MoneyTracker();
              moneyTracker.executeAccountOperations();
              break;
            }
          case "Q":
            {
              Environment.Exit(0);
              break;
            }
          default:
            {
              Console.WriteLine("Invalid option. Enter correct value or Press Q to quit");
              break;
            }
        }
      }
    }
  }
}
