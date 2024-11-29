using System;

namespace Assignment
{
  class Program
  {
    static void Main(string[] args)
    {
        Console.WriteLine("Please choose which assignment want to run");
        Console.WriteLine("1 - Assignment W47");
        Console.Write("2 - Assignment W48");
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine(" \"(Current week assignment)\"");
        Console.ResetColor();
        
        Console.Write("Enter number : "); 
        String strInputValue = Console.ReadLine().Trim();

        int iInput = ((strInputValue.Length > 0) && (strInputValue.All(char.IsDigit))) ? Convert.ToInt16(strInputValue.Trim()) : 0;
        switch(iInput){
            case 1:
            {
                AssignmentW47 assignementW47 = new AssignmentW47();
                assignementW47.w47tAssignment();
                break;
            }
            default:
            {
                AssignmentW48 assignementW48 = new AssignmentW48();
                assignementW48.w48Assignment();
                break;
            }
        }
    }
  }
}
