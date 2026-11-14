namespace Project.Tests;

public class LimitedStackTests {
    [Theory]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(2)]
    [InlineData(5)]
    public void Throws_when_exceeding_capacity(int limit) {
        LimitedStack<int> ints = new(limit);
        for (int i = 0; i < limit; i++) {
            ints.Push(i);
        }

        Assert.Throws<InvalidOperationException>(() => ints.Push(1));
    }
}