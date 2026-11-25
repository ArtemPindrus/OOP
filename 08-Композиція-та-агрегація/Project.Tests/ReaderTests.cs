namespace Project.Tests;

public class ReaderTests {
    [Fact]
    public void Borrows_a_book_when_it_exists() {
        Library lib = new([new Book("Steven King", "It"), new Book("Edogawa Rampo", "Golden Mask")]);
        Reader sut = new();

        sut.Borrow(lib, "It");

        Assert.Single(sut.BorrowedBooks);
        Assert.Contains(new Book("Steven King", "It"), sut.BorrowedBooks);

        Assert.Single(lib.Books);
        Assert.Contains(new Book("Edogawa Rampo", "Golden Mask"), lib.Books);
    }

    [Fact]
    public void Borrows_no_book_when_it_doesnt_exists() {
        Library lib = new([new Book("Steven King", "It"), new Book("Edogawa Rampo", "Golden Mask")]);
        Reader sut = new();

        sut.Borrow(lib, "Shining");

        Assert.Empty(sut.BorrowedBooks);
        Assert.Equal(2, lib.Books.Count());
    }

    [Fact]
    public void Gives_back_a_borrowed_book() {
        Book goldMask = new("Edogawa Rampo", "Golden Mask");
        Book it = new("Steven King", "It");
        Library lib = new([goldMask, it]);
        Reader sut = new();

        sut.Borrow(lib, "It");
        sut.Borrow(lib, "Golden Mask");
        sut.GiveBack(lib, "It");

        Assert.Single(sut.BorrowedBooks);
        Assert.Contains(goldMask, sut.BorrowedBooks);

        Assert.Single(lib.Books);
        Assert.Contains(it, lib.Books);
    }
}