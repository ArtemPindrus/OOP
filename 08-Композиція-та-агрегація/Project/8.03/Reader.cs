namespace Project;

public class Reader {
    private readonly List<Book> borrowedBooks = [];

    public IEnumerable<Book> BorrowedBooks => borrowedBooks;

    public void Borrow(Library library, string title) {
        if (library.GetBook(title) is Book existingBook) {
            borrowedBooks.Add(existingBook);
        }
    }

    public void GiveBack(Library library, string title) {
        Book? book = borrowedBooks.FirstOrDefault(x => x.Title == title);

        if (book is not null) {
            borrowedBooks.Remove(book);
            library.AddBook(book);
        }
    }
}