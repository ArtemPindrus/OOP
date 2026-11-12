namespace Project.Tests;

public class MatrixTests {
    [Fact]
    public void Cant_add_matrices_with_different_dimensions() {
        var a = new Matrix(2, 3);
        var b = new Matrix(3, 2);

        Assert.Throws<ArgumentException>(() => { var c = a + b; });
    }

    [Fact]
    public void Cant_multiply_matrices_with_incompatible_dimensions() {
        var a = new Matrix(2, 3);
        var b = new Matrix(2, 2);

        Assert.Throws<ArgumentException>(() => { var c = a * b; });
    }

    [Fact]
    public void Addition_works_correctly() {
        var a = Matrix.FromInitialData(new int[,] { { 1, 2 }, { 3, 4 } });
        var b = Matrix.FromInitialData(new int[,] { { 5, 6 }, { 7, 8 } });

        var result = a + b;

        Assert.Equal(6, result[0, 0]);
        Assert.Equal(8, result[0, 1]);
        Assert.Equal(10, result[1, 0]);
        Assert.Equal(12, result[1, 1]);
    }
}