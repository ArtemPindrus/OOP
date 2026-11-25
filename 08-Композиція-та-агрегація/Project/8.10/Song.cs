namespace Project;

public record class Song(string Author, string Name) {
    public Song DeepCopy() => new(
        new(Author.AsSpan()),
        new(Name.AsSpan())
    );
}