namespace Project.Tests;

public class TimeTests {
    [Fact]
    public void ToSeconds_returns_correct_value() {
        Time sut = new Time(1, 30, 15);
        int expected = 5415;

        int actual = sut.ToSeconds();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Equality_operator_returns_true_for_equal_times() {
        Time time1 = new Time(2, 15, 30);
        Time time2 = new Time(2, 15, 30);

        bool actual = time1 == time2;

        Assert.True(actual);
    }

    [Theory]
    [InlineData("12:45:50", 12, 45, 50)]
    [InlineData("00:00:00", 0, 0, 0)]
    [InlineData("23:59:59", 23, 59, 59)]
    public void FromString_returns_correct_time(string time, int hours, int minutes, int seconds) {
        Time expected = new(12, 45, 30);

        Time actual = Time.FromString(time);

        Assert.Equal(hours, actual.Hours);
        Assert.Equal(minutes, actual.Minutes);
        Assert.Equal(seconds, actual.Seconds);
    }
}