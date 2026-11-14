namespace Project;

public class Manager : Employee {
    public decimal Bonus { get; }

    public Manager(string name, decimal rate, decimal bonus) : base(name, rate) {
        if (bonus < 0) throw new ArgumentException("Bonus can't be negative.", nameof(bonus));

        Bonus = bonus;
    }

    public override decimal Pay() => base.Pay() + Bonus;
}
