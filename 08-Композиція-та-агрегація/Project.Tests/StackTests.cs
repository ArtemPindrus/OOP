namespace Project.Tests;

public class StackTests {
    [Fact]
    public void Pop_returns_last_item() {
        Stack<int> sut = new();

        for (int i = 0; i < 10; i++) {
            sut.Push(i);
        }

        int actual = sut.Pop();
        Assert.Equal(9, actual);
    }
}