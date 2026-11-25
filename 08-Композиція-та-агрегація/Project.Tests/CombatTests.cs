namespace Project.Tests;

public class CombatTests {
    [Fact]
    public void Attacks_if_first_has_Attacker_and_second_has_Health() {
        Entity a = new Entity("attacker")
            .Add(new Attacker(10));

        Entity h = new Entity("health")
            .Add(new Health(12));

        bool result = Combat.Attack(a, h);

        Assert.True(result);
        Assert.Equal(2, h.Get<Health>().Current);
    }

    [Fact]
    public void Doesnt_attack_if_first_has_no_Attacker() {
        Entity a = new("no-attacker");

        Entity h = new Entity("health")
            .Add(new Health(12));

        bool result = Combat.Attack(a, h);

        Assert.False(result);
        Assert.Equal(12, h.Get<Health>().Current);
    }

    [Fact]
    public void Doesnt_attack_if_second_has_no_Health() {
        Entity a = new Entity("attacker")
            .Add(new Attacker(10));

        Entity h = new("no-health");

        bool result = Combat.Attack(a, h);

        Assert.False(result);
    }
}