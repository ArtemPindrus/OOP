namespace Project;

public class Library {
    private readonly List<Book> books;

    /// <summary>
    /// Creates an empty library.
    /// </summary>
    public Library() {
        books = new();
    }

    /// <summary>
    /// Creates a library with an initial collection of books.
    /// </summary>
    public Library(IEnumerable<Book> books) {
        this.books = new(books);
    }

    public void Add(Book book) => books.Add(book);

    public IEnumerable<Book> Find(string author) => books.Where(b => b.Author == author);

    public int CalculateTotalPages() => books.Sum(b => b.Pages);

    public Book? GetLongestBook() => books.OrderByDescending(b => b.Pages)
        .FirstOrDefault();
}