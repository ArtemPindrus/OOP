namespace Project.Tests;

public class StackTests {
    [Theory]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(7)]
    [InlineData(5)]
    public void Pop_returns_last_pushed_item(int itemCount) {
        Stack<int> ints = new();
        int expected = itemCount - 1;
        for (int i = 0; i < itemCount; i++) {
            ints.Push(i);
        }

        int actual = ints.Pop();

        Assert.Equal(expected, actual);
    }
}