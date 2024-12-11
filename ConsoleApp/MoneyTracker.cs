using System;
using System.Collections.Generic;
using System.IO;

namespace MoneyTrackingApp
{
    class MoneyTracker
    {
        private List<TransactionInfo> items = new List<TransactionInfo>();
        private decimal balance = 0;
        int iNumberOfEntries = 0;
        bool isTransactionInfoChanged = false;
        /************************************************************************
        * This is the main function which will be invoked form the main program *
        * and will act as a main panel for Money Tracking application           *
        *************************************************************************/
        public void executeAccountOperations()
        {
            //This function will read the items stroed in a file copy into class level list
            //to do operations based on the user inputs
            items = FileManager.LoadItems();
            iNumberOfEntries = items.Count;
            CalculateBalance();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Console based Sowmya's Money tracking application");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"You have currently \' {balance} \' kr on your account\n");
                Console.ResetColor();
                Console.WriteLine("Pick an option:");
                Console.WriteLine("(1) Show items (Expense(s) / Income(s) / All)");
                Console.WriteLine("(2) Add new expense / income");
                Console.WriteLine("(3) Edit item (Edit / Remove)");
                Console.WriteLine("(4) Save");
                Console.WriteLine("(5) Quit the application");

                Console.Write("Enter input : ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": // Data display will happen this function
                        ShowItems(); 
                        break;
                    case "2": // Feeding the data will happen in this function
                        AddItem();
                        break;
                    case "3": // Data modification will happen here (Edit and Remove)
                        EditItem();
                        break;
                    case "4": // Saving the data into file will happen in this function
                        SaveItems();
                        break;
                    case "5": // Will close the application in a cleaner way after saving the data
                        QuitApplication();
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
        
        /************************************************************************
        * This function will handle to display the data based on the user need  *
        * whether to show Expenses only or Income only or All the transactions  *
        *************************************************************************/
        private void ShowItems()
        {
            Console.WriteLine("\n--- Items ---");
            Console.Write("Select category: (1 - Expense 2 - Income 3 - All Transactions)   :  ");
            var category = Console.ReadLine();

            var filteredItems = items.FindAll(item =>
                category.Equals("3", StringComparison.OrdinalIgnoreCase) ||
                item.Type.Equals(category, StringComparison.OrdinalIgnoreCase));

            foreach (var item in filteredItems)
            {
                string monthName = GetMonthName(item.Month);
                String transactionType = (item.Type == "1") ? "Expense" : "Income";
                Console.WriteLine($"{transactionType} - {item.Description} - {item.Amount} INR - {monthName}");
            }
            //If there is no entry present will inform the user with a coolured format
            if(filteredItems.Count == 0){
                String transactionType = (category == "1") ? "Expense" : "Income";
                transactionType = (category == "3") ? "Transaction" : transactionType;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"{transactionType}\'s infomation is not present. Please add the data from main menu");
                Console.ResetColor();
            }

            Console.WriteLine("----------------");
            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
        }

        /*******************************************************************************
        * This function will handle to adding the data to a class level list           *
        * and sort the list based on the transaction month and type of the transaction *
        * Possible improvement - Take the transaction date instead of month            *
        ********************************************************************************/
        private void AddItem()
        {
            Console.Write("Enter type (1 - Expense , 2 - Income) : ");
            String type = "";
            while(true){
                String strtype = Console.ReadLine();
                if(strtype == "1" || strtype == "2") {type = strtype; break;}
                else {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"Entered invalid input \' {strtype} \' enter 1 / 2");
                    Console.ResetColor();
                }
            }

            Console.Write("Enter description : ");
            var description = Console.ReadLine();

            decimal amount = 0;
            while(true){
                Console.Write("Enter amount : ");
                String strAmount = Console.ReadLine();
                if(decimal.TryParse(strAmount, out amount)) break;
                else {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"Entered invalid input \' {strAmount} \' enter only digits");
                    Console.ResetColor();
                }
            }

            int month = 0;
            while(true){
                Console.Write("Enter month (1-12) : ");
                int.TryParse(Console.ReadLine(), out month);
                if(month > 0 && month < 13) break;
                else {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"Entered invalid month \' {month} \'");
                    Console.ResetColor();
                }
            }

            items.Add(new TransactionInfo { Type = type, Description = description, Amount = amount, Month = month });

            items = items.OrderBy(item => item.Month).ThenBy(item => item.Type).ToList();

            if (type == "1")//Expneses info so subtracting from total available amount
                balance -= amount;
            else if (type == "2")//Income info so adding to total available amount
                balance += amount;

            Console.WriteLine($"Transaction info added successfully!  Press any key to return to the menu.");
        }

        /*********************************************************************************
        * This function will handle to modification / deletion of the wrongly entere data*
        * and sort the list based on the transaction month and type of the transaction   *
        ********************************************************************************/
        private void EditItem()
        {
            Console.WriteLine("\n--- Items ---");
            for (int i = 0; i < items.Count; i++)
            {
                var item = items[i];
                string monthName = GetMonthName(item.Month);
                
                String transactionType = (item.Type == "1") ? "Expense" : "Income";
                Console.WriteLine($"{i + 1}. {transactionType} - {item.Description} - {item.Amount} INR - {monthName}");
            }

            Console.Write("\nWould you like to Edit or Remove an item? (E - Edit \t R - Remove)  :  ");
            String action = "";
            while(true)
            {
                action = Console.ReadLine();
                if (action.Equals("E", StringComparison.OrdinalIgnoreCase) || action.Equals("R", StringComparison.OrdinalIgnoreCase)) break;
                else{
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"Entered invalid input \'{action}\'");
                    Console.ResetColor();
                    Console.Write("Enter (E - Edit , R - Remove)  :  ");
                }
            }
            int index;
            while(true){
                Console.Write("Enter the item number:");
                String strInput = Console.ReadLine();
                int.TryParse(strInput, out index);
                if(index > 0 && index <= items.Count) {index = index - 1; break;}
                else {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"Entered invalid index \' {strInput} \'");
                    Console.ResetColor();
                }
            }

            var selectedItem = items[index];

            if (action.Equals("E", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write($"Enter new description (current: {selectedItem.Description}):");
                var newDescription = Console.ReadLine();
                selectedItem.Description = string.IsNullOrEmpty(newDescription) ? selectedItem.Description : newDescription;

                Console.Write($"Enter new amount (current: {selectedItem.Amount}):");
                var newAmountInput = Console.ReadLine();
                decimal newAmount = string.IsNullOrEmpty(newAmountInput) ? selectedItem.Amount : decimal.Parse(newAmountInput);

                if (selectedItem.Type == "1")
                    balance += selectedItem.Amount - newAmount;
                else
                    balance -= selectedItem.Amount - newAmount;

                selectedItem.Amount = newAmount;

                Console.Write($"Enter new month (current: {selectedItem.Month}):");
                int newMonth = 0;
                while (true)
                {
                    Console.Write("Enter month (1-12) : ");
                    int.TryParse(Console.ReadLine(), out newMonth);
                    if (newMonth > 0 && newMonth < 13) { selectedItem.Month = newMonth; break; }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"Entered invalid month \' {newMonth} \'");
                        Console.ResetColor();
                    }
                }

                Console.WriteLine("Item updated successfully!");
                isTransactionInfoChanged = true;
            }
            else if (action.Equals("R", StringComparison.OrdinalIgnoreCase))
            {
                if (selectedItem.Type == "1")
                    balance += selectedItem.Amount;
                else
                    balance -= selectedItem.Amount;

                items.RemoveAt(index);
                Console.WriteLine("Item removed successfully!");
                isTransactionInfoChanged = true;
            }

            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
        }

        /*********************************************************************************
        * This function will handle to write the data into a file for persisting the user*
        * input. The handling inforamtion can find in helper class                       *
        **********************************************************************************/
        private void SaveItems()
        {
            if((items.Count > iNumberOfEntries) || isTransactionInfoChanged){
                FileManager.SaveItems(items);
                Console.WriteLine("Data saved successfully! Press any key to return to the menu.");
                iNumberOfEntries = items.Count;
                isTransactionInfoChanged = false;
            }
            else{
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("There is no new information to save! Add/Modify the data before saving");
                Console.ResetColor();
                Console.WriteLine(" Press any key to return to the menu.");
            }
            Console.ReadKey();
        }

        private void QuitApplication()
        {
            Console.WriteLine("Data saved. Exiting...");
            Environment.Exit(0);
        }

        private void CalculateBalance()
        {
            balance = 0;
            foreach (var item in items)
            {
                if (item.Type =="1")
                    balance -= item.Amount;
                else
                    balance += item.Amount;
            }
        }

        private string GetMonthName(int month)
        {
            return new DateTime(1, month, 1).ToString("MMMM");
        }
    }
}
