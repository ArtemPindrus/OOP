namespace Project.Tests;

public class VersionTests {
    [Fact]
    public void Cant_create_version_with_negative_components() {
        Assert.Throws<ArgumentException>(() => new Version(-1, 0, 0));
        Assert.Throws<ArgumentException>(() => new Version(0, -1, 0));
        Assert.Throws<ArgumentException>(() => new Version(0, 0, -1));
    }

    [Theory]
    [InlineData(1, 2, 3, "1.2.3")]
    [InlineData(10, 2, 3, "10.2.3")]
    public void ToString_formats_correctly(int maj, int min, int p, string expected) {
        var version = new Version(maj, min, p);

        var result = version.ToString();

        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void Comparisons_work_as_expected() {
        var v1 = new Version(1, 0, 0);
        var v2 = new Version(1, 0, 1);
        var v3 = new Version(1, 1, 0);
        var v4 = new Version(2, 0, 0);

        Assert.True(v2 > v1);
        Assert.True(v3 > v2);
        Assert.True(v4 > v3);
        Assert.True(v1 < v2);
        Assert.True(v2 < v3);
        Assert.True(v3 < v4);
    }
}