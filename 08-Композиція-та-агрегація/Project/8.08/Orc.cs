namespace Project;

public class Orc : Entity {
    public Orc() : base("Orc") {
        Add(new Health(100));
        Add(new Mover(3));
        Add(new Attacker(15));
    }
}
