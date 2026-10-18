using System.Text.RegularExpressions;

namespace Project;

public class Date {
    private static readonly Regex dateRegex = new(@"^(\d{4})-(\d{2})-(\d{2})$");

    public int Year { get; }
    public int Month { get; }
    public int Day { get; }

    public Date(int year, int month, int day) {
        if (year < 0) throw new ArgumentException("Year must be a positive integer.");
        if (month < 1 || month > 12) throw new ArgumentException("Month must be an integer between 1 and 12.");
        if (day < 1 || day > DaysInMonth(year, month)) throw new ArgumentException("Day is not valid for the given year and month.");

        Year = year;
        Month = month;
        Day = day;
    }

    /// <summary>
    /// Create <see cref="Date"/> instance given string in format YYYY-MM-DD.
    /// </summary>
    /// <param name="formatedDate">String in format YYYY-MM-DD.</param>
    /// <exception cref="ArgumentException"><paramref name="formatedDate"/> is of wrong format.</exception>
    public static Date FromString(string formatedDate) {
        Match match = dateRegex.Match(formatedDate);

        if (!match.Success) throw new ArgumentException("Date must be in the format YYYY-MM-DD.");

        var year = int.Parse(match.Groups[1].Value);
        var month = int.Parse(match.Groups[2].Value);
        var day = int.Parse(match.Groups[3].Value);

        return new Date(year, month, day);
    }

    /// <summary>
    /// Return whether a <paramref name="year"/> is a leap year.
    /// </summary>
    public static bool IsLeap(int year) => DateTime.IsLeapYear(year);

    /// <summary>
    /// Return number of days in this Date's month.
    /// </summary>
    public int DaysInMonth() => DaysInMonth(Year, Month);

    private int DaysInMonth(int year, int month) => DateTime.DaysInMonth(year, month);
}