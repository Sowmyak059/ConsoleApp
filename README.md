# **Learning Project: [C# Console application]**

## **Overview**
This project is a learning exercise to explore and implement concepts in **C#**. 
It focuses on **object-oriented programming, .NET Core, LINQ** allowing me to gain practical experience and build a foundational understanding of the language and its ecosystem.

## **Objectives**
The key objectives of this project include:
- Learning the basics of **C# programming**.
- Exploring and Implementing core concepts like **OOP principles, programming**.

## **Technologies Used**
- **Language**: C#
- **Framework**: .NET Core
- **Tools**: Visual Studio, Visual Studio Code
- **Testing Framework**: 

## **Features**
- **[Assignment W47]**: [Will take the product data from commandline and do the validation whether the product is having valid product name and product number(In between 200-500)]
- **[Assignment W48]**: [Will handle the below use cases
   - You should be able to add items to the list(s) until you write "q" (for quit).
   - You can see the entered data, Can get the total price of the entered data
   - You should be able to search the product is entered or not
   - All the enetered data will be in sorted order (low to high price)]
- **[Assignment W49]**: [Will handle Asset tracking use cases
   - You should be able to add items to the list(s) until you write "q" (for quit).
   - You can see the entered data, and can sort the table based on your need]
- **[Money Tracking]**: [Console based application, With this App Efficiently Manage Your Income and Expenses
   - **Key Features**:
        1. Add transactions (Income/Expense).
        2. Assign transactions to a specific month.
        3. Modify the transactions.
        4. Monitoring the transactions.
        5. Persistent data storage with save/load functionality.
   - **How it Works**:
     1. It will take the data from user about trasaction information such as Transactation type (Expense / Income), Descritption, Amount and Month
     2. The provided data will be stored in a class level user-defined type List.
     3. When the user is saved the whole data will writeen into a file which is already exist. If the file is not available will create and write the data.
     4. On every startup will read the data from the saved file.
     5. Once the data is available will caliculate and display the amount in the account.


## **Project Structure**
The project is organized as follows:
```
[Project Name]/
│
├── MainProgram.cs           # Main entry point of the application
└── Assignment47.cs          
└── Assignment48.cs
└── Assignment49.cs
└── LiveCurrency.cs          # This is a helper class to read and convert the currency conversion factors from the xml file 
└── MoneyTracker.cs
└── FileHandling.cs          # This is a helper class to do the read and write the file operations
                               required for Moneytracker application
└── MoneyTrackerHelper.cs    # This is a helper class to use the user defined list element

```

## **Setup Instructions**
To run this project locally, follow these steps:

1. **Clone the repository**:
   ```bash
   git clone https://github.com/Sowmyak059/ConsoleApp.git
   cd ConsoleApp
   ```

2. **Install .NET SDK**:  
   Ensure you have the **.NET SDK** installed on your system. You can download it from the [official .NET website](https://dotnet.microsoft.com/).

3. **Build the project**:
   ```bash
   dotnet build
   ```
 4. **Run the project**:
   ```bash
   dotnet run
   ```

## **Learning Outcomes**
Through this project, I learned:
- **[SKill 1]**: Understanding classes, inheritance and polymorphism
- **[Skill 2]**: Building Console application with C# core concepts.

## **Next Steps**
Improvements and extensions for the project:
- Keep reading this file for future updates

## **Contributing**
This project is primarily for learning purposes, but contributions are welcome.  
Feel free to fork this repository and open a pull request for any suggestions.

## **License**
This project is open sourced, licensed is not required.
