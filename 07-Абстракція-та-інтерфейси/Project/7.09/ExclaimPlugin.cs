namespace Project;

public class ExclaimPlugin : Plugin {
    public override string Name => "exclaim";
    public override string Run(string data) => data + "!";
}