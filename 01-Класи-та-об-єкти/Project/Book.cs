namespace Project;

public class Book {
    public string Title { get; }
    public string Author { get; }
    public int Pages { get; }

    public int CurrentPage { 
        get; 
        private set {
            if (value < 0) {
                throw new ArgumentException("Current page cannot be negative.", nameof(CurrentPage));
            } else if (value > Pages) {
                field = Pages;
            } else {
                field = value;
            }
        }
    }

    public Book(string title, string author, int pages, int currentPage = 0) {
        if (currentPage < 0) throw new ArgumentException("Current page cannot be negative.", nameof(currentPage));
        if (pages < 0) throw new ArgumentException("Number of pages cannot be negative.", nameof(pages));

        Title = title;
        Author = author;
        Pages = pages;
        CurrentPage = currentPage;
    }

    public void Read(int pages) {
        if (pages < 0) throw new ArgumentException("Pages to read cannot be negative.", nameof(pages));

        CurrentPage += pages;
    }

    public double GetProgressPercentage() {
        return (double)CurrentPage / Pages * 100;
    }

    public bool IsFinished() {
        return CurrentPage == Pages;
    }
}
