namespace Project;

public class UpperPlugin : Plugin {
    public override string Name => "upper";
    public override string Run(string data) => data.ToUpperInvariant();
}
