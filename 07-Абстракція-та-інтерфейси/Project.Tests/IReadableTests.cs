namespace Project.Tests;

public class IReadableTests {
    [Fact]
    public void CopyTo_copies_to_the_destination() {
        IReadable src = new ReadOnlyFile("Eaid lorem quos, in tempore, ullam.");
        MemoryFile dst = new();
        dst.Write("[TEST]");
        string expected = "[TEST]Eaid lorem quos, in tempore, ullam.";

        src.CopyTo(dst);
        string actual = dst.Read();

        Assert.Equal(expected, actual);
    }
}