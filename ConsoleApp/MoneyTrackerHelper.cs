using MoneyTrackingApp;

public class TransactionInfo
{
    public string Type { get; set; } // Expense or Income
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public int Month { get; set; } // Numeric Month (1 = January, 12 = December)
    //public DateTime Date { get; set; }


    public override string ToString()
    {
        return $"{Type},{Description},{Amount},{Month}";
    }

    public static TransactionInfo FromString(string line)
    {
        var parts = line.Split(',');
        return new TransactionInfo
        {
            Type = parts[0],
            Description = parts[1],
            Amount = decimal.Parse(parts[2]),
            Month = int.Parse(parts[3])
            //Date = DateTime.ParseExact(parts[3], "yyyy-MM-dd", CultureInfo.InvariantCulture)
        };
    }
}
