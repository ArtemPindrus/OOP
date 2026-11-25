namespace Project;

public class Library {
    private readonly List<Book> books;

    public IEnumerable<Book> Books => books;

    public Library() {
        books = [];
    }

    public Library(IEnumerable<Book> books) {
        this.books = books.ToList();
    }

    public Book? GetBook(string title) {
        Book? book = books.FirstOrDefault(x => x.Title == title);

        if (book is not null) {
            books.Remove(book);
        }

        return book;
    }

    public void AddBook(Book book) => books.Add(book);
}