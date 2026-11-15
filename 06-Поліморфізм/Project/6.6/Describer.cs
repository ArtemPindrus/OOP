using System.Text;

namespace Project;

public class Describer {
    public string? Describe(object? v) => v?.ToString();

    public string? Describe(int v) => $"Integer: {v}";

    public string? Describe(float v) => $"Float: {v}";

    public string? Describe(string v) => $"String: {v}";

    public string? Describe(IList<object> v) {
        StringBuilder sb = new();

        foreach (var item in v) {
            sb.Append(Describe(item));
        }

        return sb.ToString();
    }
}