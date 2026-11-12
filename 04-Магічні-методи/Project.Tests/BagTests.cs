namespace Project.Tests;

public class BagTests {
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void Empty_bag_has_count_zero_for_any_item(int item) {
        Bag<int> sut = new();
        int expected = 0;

        int actual = sut[item];

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData('a', 1)]
    [InlineData('b', 2)]
    [InlineData('c', 3)]
    public void Returns_correct_count_for_an_item(char item, int count) {
        Bag<char> sut = new();

        sut[item] = count;

        Assert.Equal(count, sut[item]);
    }

    [Fact]
    public void Cant_set_negative_count() {
        Bag<string> sut = new();

        Assert.Throws<ArgumentOutOfRangeException>(() => sut["item"] = -1);
    }

    [Fact]
    public void Contains_returns_true_for_items_with_positive_count() {
        Bag<string> sut = new();
        sut["item"] = 1;

        bool actual = sut.Contains("item");

        Assert.True(actual);
    }
}