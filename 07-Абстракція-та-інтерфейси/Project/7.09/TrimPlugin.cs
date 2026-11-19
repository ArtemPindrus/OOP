namespace Project;

public class TrimPlugin : Plugin {
    public override string Name => "trim";
    public override string Run(string data) => data.Trim();
}
