// See https://aka.ms/new-console-template for more information

using System;

namespace Assignment
{

class Assignment47
{
    //    This function will fullfill to take the product data from commandline and will do the validation
    //    whether the product is having valid product name and product number(In between 200-500)
   
    public void w47tAssignment()
    {
        Console.WriteLine("Skriv in produkter. Avsluta med att skriva \'exit\'");
        string[] productData = new string[0];

        while(true)
        {
            Console.Write("Enter product details:  ");
            string strInput = Console.ReadLine();
            string validateInput = strInput.Trim();
            
            if(validateInput.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }
            
            Console.ForegroundColor = ConsoleColor.Red;

            string[] splittedValues = strInput.Split('-');
            bool isValidFormat = false;
            if(splittedValues.Length == 2)
            {
                if((!splittedValues[0].Any(char.IsDigit)) && (splittedValues[0].Length > 1)){
                    isValidFormat = true;
                }
                else
                {
                    isValidFormat = false;
                    Console.WriteLine("Product name should contains only letters not digits");
                }

                if(isValidFormat && (splittedValues[1].Length > 0))
                {
                    isValidFormat = false;
                    if(splittedValues[1].All(char.IsDigit)){
                        int number = Convert.ToInt16(splittedValues[1].Trim());
                        if((number > 200) && (number < 500)){
                            isValidFormat = true;
                        }
                        else
                        {
                            Console.WriteLine("Part number should between 200 - 500");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Part number should contains only digits not letters");
                    }
                }
            }
            else
            {
                Console.WriteLine("Format is not correct enter name-number format");
            }
            if(isValidFormat){
                string[] tempProductInfo = new string[productData.Length + 1];
                productData.CopyTo(tempProductInfo,0);
                tempProductInfo[productData.Length] = strInput;
                productData = tempProductInfo;
            }
            Console.ResetColor();
        }
        Array.Sort(productData);
        foreach(string product in productData)
        {
            Console.WriteLine("*  " + product);
        }
    }
}
}