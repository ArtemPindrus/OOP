namespace Project;

public class Rock : Entity {
    public Rock() : base("Rock") {
        Add(new Health(50));
    }
}
