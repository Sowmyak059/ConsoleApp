/internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello+ World!");
        string str = Console.ReadLine();

        int integer = 10;
        float floatter = 1.0f;;
        double dbl = 2000.0f;
        long ln = 1150;

        Console.WriteLine(str + "\n integer : "+ integer+ "\n floatter : "+ floatter+
            "\n dbl : "+ dbl+ "\n ln : "+ ln);

        Console.WriteLine((Convert.ToInt16(str)+10) 
            + "\n integer : " + (Convert.ToString(integer)+" i am string") 
            + "\n floatter : " + floatter +
            "\n dbl : " + dbl + "\n ln : " + ln);

    }
}


//Date : 19-11-2024 (Strings and String Methods)
/*
int num1 = 1;
var num2 = 2;

int sum = num1 + num2;
Console.WriteLine("Sum: " + sum);

Console.Write("Enter Your Name: ");
string name = Console.ReadLine();
Console.WriteLine("Hello " + name);

// Commenting selected part CTRL + K + C
// Un - Commenting selected part CTRL + K + U


string data = "Lexicon Malmö ";
//data = "Stocholm";
//Console.WriteLine(data[0]);
//data[0] = 'D';  // strings are immutable because of that we cannot change directly string.
string all = data.Substring(0);                 //Lexicon Malmö 
string partOne = data.Substring(0, 7);          //Lexicon
string partTwo = data.Substring(8, 5);          //Malmö 
string dataRemove = data.Remove(8);             //Lexicon 
string dataReplace = data.Replace("Lexicon", "Leksikon");   //Leksikon Malmö 
string dataReplace1 = data.Replace(partOne, partTwo);       //Malmö Malmö 
string dataTrimmed = data.Trim();                           //Lexicon       Malmö  
string[] parts = data.Split();

string[] partsTrimmed = data.Trim().Split();



Console.ReadLine();
*/

//Date : 20-11-2024 (String Array)
/*
string[] myStr1;
myStr1 = new string[2];
myStr1[0] = "D";

string[] myStr2 = { "a", "b", "c" };
int index = 0;
// Create a String Array
// Add string elements into this array
// User can enter elements until type "exit" (but it will limit to 10 elements)
// After typing "Exit" program must show the list of the elements of Array

string[] myCars = new string[10];
Console.WriteLine("Add a car and close with 'Exit'");

while (true)
{
    Console.Write("Add a car brand: ");
    string data = Console.ReadLine();
    if (data.ToLower().Trim() == "exit")
    {
        break;
    }

    myCars[index] = data;
    index++;
}

Array.Resize(ref myCars, index);
Console.WriteLine("MyCars with unsorted");
for (int i = 0; i < myCars.Length; i++)
{
    Console.WriteLine(myCars[i]);
}

Array.Sort(myCars);
Console.WriteLine("MyCars with sorted with foreach loop");
foreach (string car in myCars)
{
    Console.WriteLine(car);
}
*/

//Date : 21-11-2024(Int Array program)
/*
Console.WriteLine("Input Numbers and type 'exit' to show list");
int[] valueArray = new int[0];
int index = 0;

while (true)
{
    Console.Write("Input Number: ");
    string data = Console.ReadLine();
    if (data.ToLower().Trim() == "exit")
    {
        break;
    }

    bool isInt = int.TryParse(data, out int value);
    bool isDouble = double.TryParse(data, out double dValue);


    if (isDouble)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{data} is a Decimal Number"); // interpolation
        Array.Resize(ref valueArray, valueArray.Length + 1);
        valueArray[index] = (int)dValue;
        index++;
    }
    else if (isInt)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{data} is a Number"); // interpolation
        Array.Resize(ref valueArray, valueArray.Length + 1);
        valueArray[index] = value;
        index++;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        //Console.WriteLine($"{data} is NOT a Number");
        Console.WriteLine("{0} is NOT a Number", data);
        //Console.WriteLine(data, " is not a Number");
    }

    Console.ResetColor();
    //Console.WriteLine(isInt);
    //Console.WriteLine(value);
    //Array.Resize(ref valueArray, valueArray.Length + 1);
    ////valueArray[index] = int.Parse(data);
    //valueArray[index] = Convert.ToInt32(data);
    //index++;


}

Console.WriteLine("---------------");
Console.WriteLine("Your Numbers");
foreach (int element in valueArray)
{
    Console.WriteLine(element);
}


Console.WriteLine("---------------");
Console.WriteLine("Your Numbers - Sorted");
Array.Sort(valueArray);
foreach (int element in valueArray)
{
    Console.WriteLine(element);
}

Console.ReadLine();
*/


//Date : 25-11-2024(Methods)

/*
string myString = "";

Console.WriteLine(myString);
//if (myString == null || myString.Length == 0)
//{

//}

if (myString == null || myString == "")
{
    Console.WriteLine("String is empty or null");
}

if (string.IsNullOrEmpty(myString))
{
    Console.WriteLine("String is empty or null");
}

//void MyMethod()
//{
//    Console.WriteLine("Hello C#");
//}

//MyMethod(); // Calling the Method
//MyMethod();
//MyMethod();

void MyMethod(string name)
{
    Console.WriteLine("Hello " + name);
}

MyMethod("Jane"); // Calling the Method
MyMethod("Sara");
MyMethod("Henrik");

Console.WriteLine(Math.Pow(2,3));
// 2 * 2 * 2

int Power(int num, int power)
{
    int result = 1;
    for (int i = 0; i < power; i++)
    {
        result *= num;
    }
    return result;
}

int value = Power(2, 3);

Console.WriteLine(value);


Console.WriteLine("Enter a Number");
Console.WriteLine("1-Add a Product");
Console.WriteLine("2-Search a Product");
Console.WriteLine("3-List Products");
Console.WriteLine("0-Quit");

Console.Write("Enter a Number");
string userInput = Console.ReadLine();
switch (userInput)
{
    case "1":
        AddProduct();
        break;
    case "2":
        SearchProduct();
        break;
    case "3":
        ListProducts();
        break;
    case "0":
        Console.WriteLine("Thank you for using this application");
        break;
    default:
        Console.WriteLine("Invalid Selection");
        //ShowMainMenu();
        break;
}

void AddProduct()
{

}

void SearchProduct()
{

}


void ListProducts()
{

}

class Asset
{

}
*/










