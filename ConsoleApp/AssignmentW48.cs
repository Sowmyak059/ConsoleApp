using System;

namespace Assignment
{
/*
    The purpose of this case is to handle the below use cases
    - You should be able to add items to the list(s) until you write "q" (for quit).
    - You can see the entered data, Can get the total price of the entered data
    - You should be able to search the product is entered or not
    - All the enetered data will be in sorted order (low to high price)
*/
class ItemInfo
{
        private global::System.String category;
        private global::System.String productName;

        public string Category { get => category; set => category = value; }
        public string ProductName { get => productName; set => productName = value; }
        public int Price { get; set; }
}

class AssignmentW48
{
    List<ItemInfo> productDetails = new List<ItemInfo>();
    public void w48Assignment()
    {
        String strInputValue = "P";
        do{
            switch(strInputValue.ToUpper())
            {
                case "P":
                    enterProductData();
                    break;
                case "S":
                {
                    Console.Write("Enter a Product Name to search :");
                    printTheEnteredData(Console.ReadLine().Trim());
                    break;
                }
                default:
                    break;
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("To enter a new product - enter \"p\" | To search a product - enter \"S\" | To quit - enter: \"Q\"");
            Console.ResetColor();
            strInputValue = Console.ReadLine().Trim();
        }
        while(!bValidateTheInput(strInputValue));
    }
    private void enterProductData()
    {
        while(true)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("To enter a new product - follow the steps | To quit - enter: \"Q\"");
            Console.ResetColor();
            try
            {
                String strInputValue = "";
                ItemInfo item = new ItemInfo();
                Console.Write("Enter a Category: "); 
                strInputValue = Console.ReadLine().Trim();
                if(bValidateTheInput(strInputValue)){ break; }
                item.Category = strInputValue;

                Console.Write("Enter a Product Name: ");
                strInputValue = Console.ReadLine().Trim();
                if(bValidateTheInput(strInputValue)){ break; }
                item.ProductName = strInputValue;

                Console.Write("Enter a Price: ");
                strInputValue = Console.ReadLine().Trim();
                if(bValidateTheInput(strInputValue)){ break; }
                item.Price =  ((strInputValue.Length > 0) && (strInputValue.All(char.IsDigit))) ? Convert.ToInt16(strInputValue.Trim()) : 0;

                productDetails.Add(item);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The product was successfully added!");
                Console.ResetColor();
                Console.WriteLine("---------------------------------------------------------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
            finally
            {
            }
        }

        printTheEnteredData();
    }
    private void printTheEnteredData(String strSearchItem = "")
    {
        if(productDetails.Count > 0) 
        {
            productDetails.Sort((x,y) => x.Price.CompareTo(y.Price));
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Category".PadRight(25) +  "Product".PadRight(25) + "Price".PadRight(25));
            Console.ResetColor();
            int price = 0;
            foreach(ItemInfo info in productDetails)
            {
                price += info.Price;
                if((strSearchItem != "") && (info.ProductName.ToLower() == strSearchItem.ToLower()))
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(info.Category.PadRight(25) + info.ProductName.PadRight(25) + info.Price.ToString());
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(info.Category.PadRight(25) + info.ProductName.PadRight(25) + info.Price.ToString());
                }
            }
            if(strSearchItem == "") 
            {
                Console.WriteLine("\t\t\tToatal amount:".PadRight(28) + price);
            }
            Console.WriteLine("---------------------------------------------------------------------------------");
        }
    }    private bool bValidateTheInput(String strInput)
    {
        return (strInput.Trim().ToLower() == "q");
    }
}
}