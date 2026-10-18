namespace Project.Tests;

public class DateTests {
    [TestCase("2025-10-01", 2025, 10, 1)]
    [TestCase("2022-01-05", 2022, 1, 5)]
    public void FromString_ReturnsCorrectDate(string str, int year, int month, int day) {
        Date d = Date.FromString(str);

        Assert.That(d.Year, Is.EqualTo(year));
        Assert.That(d.Month, Is.EqualTo(month));
        Assert.That(d.Day, Is.EqualTo(day));
    }

    [TestCase(2016, true)]
    [TestCase(2020, true)]
    [TestCase(2024, true)]
    [TestCase(2028, true)]
    [TestCase(2032, true)]
    [TestCase(2017, false)]
    [TestCase(2018, false)]
    public void IsLeap_ReturnsCorrectValue(int year, bool expected) {
        Assert.That(Date.IsLeap(year), Is.EqualTo(expected));
    }

    [TestCase(2016, 2, 29)]
    [TestCase(2017, 2, 28)]
    [TestCase(2018, 1, 31)]
    public void DaysInMonth_ReturnsCorrectValue(int year, int month, int expected) {
        Date d = new(year, month, 1);

        Assert.That(d.DaysInMonth(), Is.EqualTo(expected));
    }
}