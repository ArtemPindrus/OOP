namespace Project.Tests;

public class MemoryFileTests {
    [Fact]
    public void Read_returns_correct_string_after_writes() {
        string expected = "hello, world!";
        MemoryFile sut = new();

        sut.Write("hello,");
        sut.Write(" world!");

        string actual = sut.Read();

        Assert.Equal(expected, actual);
    }
}