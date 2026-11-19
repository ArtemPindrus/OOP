using System.Text;

namespace Project;

public abstract class Report {
    public string Build() {
        var sb = new StringBuilder();
        sb.AppendLine(Header());

        foreach (var line in Lines()) {
            sb.AppendLine(line);
        }

        sb.Append(Footer());

        return sb.ToString();
    }

    protected abstract string Header();
    protected abstract IEnumerable<string> Lines();
    protected virtual string Footer() => "=== End of report ===";
}
