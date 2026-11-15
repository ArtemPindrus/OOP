namespace Project.Tests;

public class SmsNotifierTests {
    [Fact]
    public void Truncates_message_to_20_characters() {
        string message = "hello, some random message in here to test this thing out";
        string expected = "[SMS to Bob] hello, some random m";

        SmsNotifier sut = new();

        string actual = sut.Send("Bob", message);

        Assert.Equal(expected, actual);
    }
}