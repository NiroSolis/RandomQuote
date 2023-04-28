using Microsoft.Win32;

namespace RandomQuote_console;

internal class Program
{
    static void Main(string[] args)
    {
        List<string> quotes = File.ReadAllLines("quotes.txt").ToList();
        quotes.RemoveAll(string.IsNullOrEmpty);
        Random random = new();
        string quote = quotes[random.Next(0, quotes.Count + 1)];

        while (quote[0] == '#')
            quote = quotes[random.Next(0, quotes.Count + 1)];

        AddQuoteToRegistry(quote);
    }

    private static void AddQuoteToRegistry(string quote)
    {
        RegistryKey key =
            Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System", true) ??
            CreateAndReturnKey();

        var values = quote.Split('|');
        key.SetValue("legalnoticecaption", values[0]);
        key.SetValue("legalnoticetext", values[1]);
        key.Close();
    }

    private static RegistryKey CreateAndReturnKey()
    {
        RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\", true)!;
        key.CreateSubKey(@"Microsoft\Windows\CurrentVersion\Policies\System");
        return key;
    }
}
