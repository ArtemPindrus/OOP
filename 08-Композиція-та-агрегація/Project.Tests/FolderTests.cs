namespace Project.Tests;

public class FolderTests {
    [Fact]
    public void Finds_file_paths_correctly() {
        Folder sut = new("F1", [
            new Folder("F2", [
                new File("secret.txt", 10),
                new File("MyFile.txt", 10),
            ])
        ]);

        string? actual = sut.Find("MyFile.txt");

        Assert.NotNull(actual);
        Assert.Equal("F1/F2/MyFile.txt", actual);
    }

    [Fact]
    public void Returns_null_when_file_doesnt_exist() {
        Folder sut = new("F1", [
            new Folder("F2", [
                new File("MyFile.txt", 10)
            ])
        ]);

        string? actual = sut.Find("MyFile2.txt");

        Assert.Null(actual);
    }
}