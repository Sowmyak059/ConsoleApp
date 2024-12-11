using MoneyTrackingApp;
public static class FileManager
{
    private static string filePath = "money_data.txt";

    public static List<TransactionInfo> LoadItems()
    {
        var items = new List<TransactionInfo>();
        if (File.Exists(filePath))
        {
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                items.Add(TransactionInfo.FromString(line));
            }
        }
        return items;
    }

    public static void SaveItems(List<TransactionInfo> items)
    {
        var lines = new List<string>();
        foreach (var item in items)
        {
            lines.Add(item.ToString());
        }
        File.WriteAllLines(filePath, lines);
    }
}
