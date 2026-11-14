namespace Project;

public class Developer : Employee {
    private const decimal AllowancePerLevel = 200m;

    public int Level { get; }

    public Developer(string name, decimal rate, int level) : base(name, rate) {
        if (level < 0) throw new ArgumentException("Level can't be negative.", nameof(level));

        Level = level;
    }

    public decimal Allowance => Level * AllowancePerLevel;

    public override decimal Pay() => base.Pay() + Allowance;
}
