using CurrencyConverter;

namespace Assignment
{
    internal class AssetTrack_WithDB
    {
        AssetTrackingDBContext _dbContext = new AssetTrackingDBContext();
        public void executeAssetsProject()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\n --------  Welcome to Asset Managment Application (W49)-------- ");
            Console.ResetColor();
            String strInputValue = "A";
            do
            {
                LiveCurrency.FetchRates();
                switch (strInputValue.ToUpper())
                {
                    case "A":
                        insertProductData();
                        break;
                    case "U":
                        updateProductData();
                        break;
                    case "D":
                        deleteProductData();
                        break;
                    case "P":
                        printTheEnteredData();
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

                Console.ForegroundColor = ConsoleColor.Blue;  Console.WriteLine("\nPlease provide Which action you want perform"); Console.ResetColor();
                Console.WriteLine("\"A\" - Add new product   |  \"S\" - Sort products  | \"D\" -To Delete | \"U\" - To update | | \"P\" - To see the products");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\"Q\" - Quit & See the assets");
                strInputValue = Console.ReadLine().Trim();
                Console.ResetColor();
            }
            while (!bValidateTheInput(strInputValue));
            printTheEnteredData();
        }
        
        /*Insert*/
        private void insertProductData()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("To enter a new product - follow the steps | To quit - enter: \"Q\"");
                Console.ResetColor();
                try
                {
                    AssetTrack_ItemInfo itemInfo = new AssetTrack_ItemInfo();
                    Console.Write("Enter Product Type 1 - Laptop | 2 - Mobile : ");
                    itemInfo.Type = Console.ReadLine().Trim() switch { "1" => "Laptop", "2" => "Mobile", _ => "Q"};
                    if (bValidateTheInput(itemInfo.Type)) { break; }

                    Console.Write("Enter Brand Name : ");
                    itemInfo.Brand = Console.ReadLine().Trim(); if (bValidateTheInput(itemInfo.Brand)) { break; }

                    Console.Write("Enter Model : ");
                    itemInfo.Model = Console.ReadLine().Trim(); if (bValidateTheInput(itemInfo.Model)) { break; }

                    Console.Write("Enter office location : ");
                    itemInfo.Location = Console.ReadLine().Trim(); if (bValidateTheInput(itemInfo.Location)) { break; }

                    Console.Write("Enter currency unit at your location  1 - \'SEK\' 2 - \'EUR\' 3 or any key - \'USD\' : ");
                    itemInfo.Currency = Console.ReadLine().Trim() switch { "1" => "SEK", "2" => "EUR", _ => "USD" };

                    Console.Write("Enter Price in USD : ");
                    double.TryParse(Console.ReadLine(), out double dPriceInUSD);

                    itemInfo.PriceInUSD = dPriceInUSD;

                    Console.Write("Enter purchase Date (MM/DD/YYYY) : ");
                    String strPurchaseDate = Console.ReadLine().Trim();
                    if (!DateTime.TryParse(strPurchaseDate, out DateTime dt))
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"{strPurchaseDate} is not a valid date string updating with Todsy's date");
                        Console.ResetColor();
                        dt = DateTime.Today;
                    }
                    itemInfo.PurchaseDate = dt;

                    itemInfo.LocalPrice = LiveCurrency.Convert(dPriceInUSD, "USD", itemInfo.Currency);

                    _dbContext.Assets.Add(itemInfo);
                    _dbContext.SaveChanges();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("The product was successfully added!"); Console.ResetColor();
                    Console.WriteLine("---------------------------------------------------------------------------------");
                }
                catch (Exception ex) { Console.WriteLine($"Unexpected error: {ex.Message}"); }
                finally { }
            }
        }

        /*Select*/
        private void printTheEnteredData(String strSearchItem = "")
        {
            if (_dbContext == null) return;

            List<AssetTrack_ItemInfo> assetsDetails = _dbContext.Assets.ToList();

            if (assetsDetails.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Type".PadRight(10) + "Brand".PadRight(10) + "Model".PadRight(10) + "Office".PadRight(15) + "Purchase Date".PadRight(25)
                + "Price in USD".PadRight(15) + "Currency".PadRight(10) + "Local price today".PadRight(10));

                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
                Console.ResetColor();

                assetsDetails = filterTheResults(strSearchItem, assetsDetails);
                foreach (AssetTrack_ItemInfo asset in assetsDetails)
                {
                    DateTime todaysDate = DateTime.Now;
                    TimeSpan difference = todaysDate - asset.PurchaseDate;
                    int numberOfDaysForThreeYears = 365 * 3;
                    int result = numberOfDaysForThreeYears - (int)Math.Round(difference.TotalDays);

                    if (result <= 90) Console.ForegroundColor = ConsoleColor.Red;
                    else if (result <= 180) Console.ForegroundColor = ConsoleColor.Yellow;
                    else Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine(asset.Type.PadRight(10) + asset.Brand.PadRight(10) + asset.Model.PadRight(10)
                    + asset.Location.PadRight(15) + asset.PurchaseDate.ToShortDateString().PadRight(25) + asset.PriceInUSD.ToString().PadRight(15)
                    + asset.Currency.PadRight(10) + asset.LocalPrice.ToString().PadRight(10));
                    Console.ResetColor();
                }
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            }
        }
       
        /*Update*/
        private void updateProductData()
        {
            if (_dbContext == null) return;
            List<AssetTrack_ItemInfo> assetsDetails = _dbContext.Assets.ToList();

            Console.Write("Enter Product Type you want to update \'1\' - Laptop | \'2\' - Mobile : ");
            String strProductType = Console.ReadLine().Trim() switch { "1" => "Laptop", _ => "Mobile" };

            Console.Write("Model name : ");
            String strModel = Console.ReadLine().Trim();

            AssetTrack_ItemInfo assetTrack_ItemInfo = assetsDetails.FirstOrDefault(x => ((x.Model.StartsWith(strModel) && (x.Type.Equals(strProductType)))));

            if (assetTrack_ItemInfo != null)
            {
                Console.Write("Enter Product Type 1 - Laptop | 2 - Mobile : ");
                assetTrack_ItemInfo.Type = Console.ReadLine().Trim() switch { "1" => "Laptop", _ => "Mobile" };

                Console.Write("Enter Brand Name : ");
                assetTrack_ItemInfo.Brand = Console.ReadLine().Trim();

                Console.Write("Enter Model : ");
                assetTrack_ItemInfo.Model = Console.ReadLine().Trim();

                Console.Write("Enter office location : ");
                assetTrack_ItemInfo.Location = Console.ReadLine().Trim();

                Console.WriteLine("Enter currency unit at your location  1 - \'SEK\' 2 - \'EUR\' 3 or any key - \'USD\'");
                assetTrack_ItemInfo.Currency = Console.ReadLine().Trim() switch { "1" => "SEK", "2" => "EUR", _ => "USD" };

                Console.Write("Enter Price in USD : ");
                double.TryParse(Console.ReadLine(), out double dPriceInUSD);

                assetTrack_ItemInfo.PriceInUSD = dPriceInUSD;

                Console.Write("Enter purchase Date (MM/DD/YYYY) : ");
                String strPurchaseDate = Console.ReadLine().Trim();
                if (!DateTime.TryParse(strPurchaseDate, out DateTime dt))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"{strPurchaseDate} is not a valid date string updating with Today's date");
                    Console.ResetColor();
                    dt = DateTime.Today;
                }
                assetTrack_ItemInfo.PurchaseDate = dt;

                assetTrack_ItemInfo.LocalPrice = LiveCurrency.Convert(dPriceInUSD, "USD", assetTrack_ItemInfo.Currency);

                _dbContext.Assets.Update(assetTrack_ItemInfo);
                _dbContext.SaveChanges();

                printTheEnteredData();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Invalid data provided Please retry");
                Console.ResetColor();
                Console.ResetColor();
            }
        }

        /*Delete*/
        private void deleteProductData()
        {
            if (_dbContext == null) return;
            List<AssetTrack_ItemInfo> assetsDetails = _dbContext.Assets.ToList();

            Console.Write("Enter Product Type you want to Delete \'1\' - Laptop | \'2\' - Mobile : ");
            String strProductType = Console.ReadLine().Trim() switch { "1" => "Laptop", _ => "Mobile" };

            Console.Write("Model name :");
            String strModel = Console.ReadLine().Trim();

            AssetTrack_ItemInfo assetTrack_ItemInfo = assetsDetails.FirstOrDefault(x => ((x.Model.StartsWith(strModel) && (x.Type.Equals(strProductType)))));


            if (assetTrack_ItemInfo != null)
            {
                _dbContext.Assets.Remove(assetTrack_ItemInfo);
                _dbContext.SaveChanges();

                printTheEnteredData();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Invalid data provided Please retry");
                Console.ResetColor();
            }
        }

        private List<AssetTrack_ItemInfo> filterTheResults(String strSearchItem, List<AssetTrack_ItemInfo> assetsDetails)
        {
            List<AssetTrack_ItemInfo> sortedList;
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
