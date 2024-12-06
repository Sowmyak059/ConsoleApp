// See https://aka.ms/new-console-template for more information

using System;
using MainProject;

namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                printProjectIndex();
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
                            Console.WriteLine("In progress please wait for some time");
                            //MoneyTracker moneyTracker = new MoneyTracker();
                            //moneyTracker.executeAccountOperations();
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

        private static void printProjectIndex()
        {
            Console.WriteLine("Please choose which assignment want to run \n1 - W47 Mini Project \n2 - W48 Mini Project");
            Console.Write("3 - W49 Mini Project");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(" \"(Current week Mini Project)\"\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("A - for Individual Project");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Enter which application to launch or Press Q for quit the application : ");
            Console.ResetColor();

        }
    }
}
