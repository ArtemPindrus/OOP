namespace Project;

public class Tower : Entity {
    public Tower() : base("Tower") {
        Add(new Health(300));
        Add(new Attacker(40));
    }
}
