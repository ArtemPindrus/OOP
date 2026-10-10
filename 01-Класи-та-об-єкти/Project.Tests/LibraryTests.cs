namespace Project.Tests;

public class LibraryTests {
    public void Find_ShouldReturnBooksByAuthor_WhenAuthorExists() {
        // Arrange
        var library = new Library();
        var book1 = new Book("Book 1", "Author A", 100);
        var book2 = new Book("Book 2", "Author B", 200);
        var book3 = new Book("Book 3", "Author A", 150);
        library.Add(book1);
        library.Add(book2);
        library.Add(book3);

        // Act
        var result = library.Find("Author A");

        // Assert
        Assert.Multiple(() => {
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result, Does.Contain(book1));
            Assert.That(result, Does.Contain(book3));
            Assert.That(result, Does.Not.Contain(book2));
        });
    }

    [Test]
    public void CalculateTotalPages_ReturnsCorrectSum_WhenBooksExist() {
        // Arrange
        var library = new Library();
        library.Add(new Book("Book 1", "Author A", 100));
        library.Add(new Book("Book 2", "Author B", 200));
        library.Add(new Book("Book 3", "Author C", 150));

        // Act
        var totalPages = library.CalculateTotalPages();

        // Assert
        Assert.That(totalPages, Is.EqualTo(450));
    }

    [Test]
    public void CalculateTotalPages_ReturnsZero_WhenNoBooksExist() {
        // Arrange
        var library = new Library();

        // Act
        var totalPages = library.CalculateTotalPages();

        // Assert
        Assert.That(totalPages, Is.EqualTo(0));
    }

    [Test]
    public void GetLongestBook_ReturnsBookWithMostPages_WhenBooksExist() {
        // Arrange
        var library = new Library();
        var book1 = new Book("Book 1", "Author A", 100);
        var book2 = new Book("Book 2", "Author B", 200);
        var book3 = new Book("Book 3", "Author C", 150);
        library.Add(book1);
        library.Add(book2);
        library.Add(book3);

        // Act
        Book? longestBook = library.GetLongestBook();

        // Assert
        Assert.That(longestBook, Is.EqualTo(book2));
    }

    [Test]
    public void GetLongestBook_ReturnsNull_WhenNoBooksExist() {
        // Arrange
        var library = new Library();

        // Act
        Book? longestBook = library.GetLongestBook();

        // Assert
        Assert.That(longestBook, Is.Null);
    }
}