namespace Project;

public class Folder : IFileSystemComponent {
    private readonly List<IFileSystemComponent> children;

    public string Name { get; }
    public double Size => children.Sum(c => c.Size);
    public int Count => children.Count;

    public Folder(string name) {
        Name = name;
        children = [];
    }

    public Folder(string name, IEnumerable<IFileSystemComponent> children) {
        Name = name;
        this.children = children.ToList();
    }

    public string? Find(string name) {
        foreach (var c in children) {
            if (c.Find(name) is string partialPath) return $"{Name}/{partialPath}";
        }

        return null;
    }
}
