namespace Project;

public record class File(string Name, double Size) : IFileSystemComponent {
    public int Count => 0;

    public string? Find(string name) {
        return Name == name ? Name : null;
    }
}