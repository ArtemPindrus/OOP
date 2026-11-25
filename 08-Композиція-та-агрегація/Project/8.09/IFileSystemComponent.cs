namespace Project;

public interface IFileSystemComponent {
    string Name { get; }
    double Size { get; }

    /// <summary>
    /// Number of children.
    /// </summary>
    int Count { get; }

    /// <summary>
    /// Return the path to children.
    /// </summary>
    /// <param name="name">Name of children.</param>
    /// <returns>Path to children.</returns>
    string? Find(string name);
}