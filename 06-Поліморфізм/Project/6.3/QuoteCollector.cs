namespace Project;

public static class QuoteCollector {
    public static string[] Chorus(IEnumerable<object> objects) {
        List<string> quotes = [];

        foreach (var i in objects) {
            string? quote = GetQuote(i);

            if (quote is not null) quotes.Add(quote);
        }

        return quotes.ToArray();
    }

    private static string? GetQuote(object obj) {
        object? result = obj.GetType()?.GetMethod("Quote")?.Invoke(obj, null);

        return result as string;
    }
}