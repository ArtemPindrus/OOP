namespace Project.Tests;

public class CountingStackTests {
    [Theory]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(7)]
    [InlineData(5)]
    public void Counts_number_of_pushes_correctly(int itemCount) {
        CountingStack<int> ints = new();
        for (int i = 0; i < itemCount; i++) {
            ints.Push(i);
        }

        int actual = ints.PushCount;

        Assert.Equal(itemCount, actual);
    }
}