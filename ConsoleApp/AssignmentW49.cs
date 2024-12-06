using System;
using System.Collections.Generic;
using System.Diagnostics;
using CurrencyConverter;

namespace Assignment
{
    /*
        The purpose of this case is to handle Asset tracking use cases
        - You should be able to add items to the list(s) until you write "q" (for quit).
        - You can see the entered data, and can sort the table based on your need
    */
    class AssetsInfo
    {
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Location { get; set; }
        public double PriceInUSD { get; set; }
        public string Currency { get; set; }
        public double LocalPrice { get; set; }
        public DateTime PurchaseDate { get; set; }

        public AssetsInfo(string type, string brand, string model, string location, double priceInUSD, string currency, double localPrice, DateTime purchaseDate)
        {
            Type = type;
            Brand = brand;
            Model = model;
            Location = location;
            PriceInUSD = priceInUSD;
            Currency = currency;
            LocalPrice = localPrice;
            PurchaseDate = purchaseDate;
        }
    }

    class AssignmentW49
    {
        List<AssetsInfo> assetsDetails = new List<AssetsInfo>();
        public void w49Assignment()
        {
            LiveCurrency.FetchRates();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\n --------  Welcome to Asset Managment Application (W49)-------- ");
            Console.ResetColor();
            String strInputValue = "P";
            do
            {
                switch (strInputValue.ToUpper())
                {
                    case "P":
                        enterProductData();
                        break;
                    case "S":
                        {
                            Console.WriteLine("Choose how to sort the list");
                            Console.WriteLine(" 1 - Type \n 2 - Brand \n 3 - Model \n 4 - Purchase Date");
                            Console.WriteLine(" 5 - Price \n 6 - Currency type \n Any other option - Office Location ");
                            printTheEnteredData(Console.ReadLine().Trim());
                            break;
                        }
                    default:
                        break;
                }

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("To enter a new product - enter \"p\" | To Sort a asset list - enter \"S\" | To quit - enter: \"Q\"");
                Console.ResetColor();
                strInputValue = Console.ReadLine().Trim();
            }
            while (!bValidateTheInput(strInputValue));
        }
        private void enterProductData()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("To enter a new product - follow the steps | To quit - enter: \"Q\"");
                Console.ResetColor();
                try
                {
                    Console.Write("Enter Product Type : ");
                    String strProductType = Console.ReadLine().Trim(); if (bValidateTheInput(strProductType)) { break; }

                    Console.Write("Enter Brand Name : ");
                    String strBrandName = Console.ReadLine().Trim(); if (bValidateTheInput(strBrandName)) { break; }

                    Console.Write("Enter Model : ");
                    String strModel = Console.ReadLine().Trim(); if (bValidateTheInput(strModel)) { break; }

                    Console.Write("Enter office location : ");
                    String strLocation = Console.ReadLine().Trim(); if (bValidateTheInput(strLocation)) { break; }

                    Console.WriteLine("Enter currency unit at your location   1 - \'SEK\'\t2 - \'EUR\'\t3 or any key - \'USD\'");
                    String strCurrency = Console.ReadLine().Trim() switch { "1" => "SEK", "2" => "EUR", _ => "USD" };

                    Console.Write("Enter Price in USD : ");
                    double.TryParse(Console.ReadLine(), out double dPriceInUSD);

                    Console.Write("Enter purchase Date (MM/DD/YYYY) : ");
                    String strPurchaseDate = Console.ReadLine().Trim();
                    if (!DateTime.TryParse(strPurchaseDate, out DateTime dt)) {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"{strPurchaseDate} is not a valid date string updating with Todsy's date");
                        Console.ResetColor();
                        dt = DateTime.Today;
                    }

                    double dLocalPrice = LiveCurrency.Convert(dPriceInUSD, "USD", strCurrency);
                    assetsDetails.Add(new AssetsInfo(strProductType, strBrandName, strModel, strLocation, dPriceInUSD, strCurrency, dLocalPrice, dt));

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("The product was successfully added!"); Console.ResetColor();
                    Console.WriteLine("---------------------------------------------------------------------------------");
                }
                catch (Exception ex) { Console.WriteLine($"Unexpected error: {ex.Message}"); }
                finally { }
            }
            printTheEnteredData();
        }
        private void printTheEnteredData(String strSearchItem = "")
        {
            if (assetsDetails.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Type".PadRight(10) + "Brand".PadRight(10) + "Model".PadRight(10) + "Office".PadRight(15) + "Purchase Date".PadRight(25)
                + "Price in USD".PadRight(15) + "Currency".PadRight(10) + "Local price today".PadRight(10));

                Console.WriteLine("--------------------------------------------------------------------------------------------------------");
                Console.ResetColor();

                assetsDetails = filterTheResults(strSearchItem);
                foreach (AssetsInfo asset in assetsDetails)
                {
                    DateTime todaysDate = DateTime.Now;
                    TimeSpan difference = todaysDate - asset.PurchaseDate;
                    int numberOfDaysForThreeYears = 365 * 3;
                    int result = numberOfDaysForThreeYears - (int)Math.Round(difference.TotalDays);

                    if (result <= 90) Console.ForegroundColor = ConsoleColor.Red;
                    else if (result <= 180)  Console.ForegroundColor = ConsoleColor.Yellow;
                    else Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine(asset.Type.PadRight(10) + asset.Brand.PadRight(10) + asset.Model.PadRight(10)
                    + asset.Location.PadRight(15) + asset.PurchaseDate.ToShortDateString().PadRight(25) + asset.PriceInUSD.ToString().PadRight(15)
                    + asset.Currency.PadRight(10) + asset.LocalPrice.ToString().PadRight(10));

                    Console.ResetColor();
                }
                Console.WriteLine("---------------------------------------------------------------------------------");
            }
        }

        private List<AssetsInfo> filterTheResults(String strSearchItem)
        {
            List<AssetsInfo> sortedList;
            switch (strSearchItem)
            {
                case "1"://Type
                    sortedList = assetsDetails.OrderBy(asset => asset.Type).ThenByDescending(asset => asset.PurchaseDate).ToList();
                    break;
                case "2"://Brand
                    sortedList = assetsDetails.OrderBy(asset => asset.Brand).ThenByDescending(asset => asset.PurchaseDate).ToList();
                    break;
                case "3"://Model
                    sortedList = assetsDetails.OrderBy(asset => asset.Model).ThenByDescending(asset => asset.PurchaseDate).ToList();
                    break;
                case "4": // Purchase date && Type
                    sortedList = assetsDetails.OrderByDescending(asset => asset.PurchaseDate).ThenBy(asset => asset.Type).ToList();
                    break;
                case "5"://Price
                    sortedList = assetsDetails.OrderByDescending(asset => asset.PriceInUSD).ThenByDescending(asset => asset.PurchaseDate).ToList();
                    break;
                case "6": // currency && Type
                    sortedList = assetsDetails.OrderByDescending(asset => asset.Currency).ThenBy(asset => asset.Type).ToList();
                    break;
                default:
                    sortedList = assetsDetails.OrderBy(asset => asset.Location).ThenByDescending(asset => asset.PurchaseDate).ToList();
                    break;
            }
            return sortedList;
        }
        private bool bValidateTheInput(String strInput)
        {
            return ((strInput != null) && (strInput.Trim().ToLower() == "q"));
        }
    }
}