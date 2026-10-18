namespace Project;

public class Ticket {
    public static int Created { get; private set; } = 0;

    public int Id { get; }

    public Ticket() {
        Id = ++Created;
    }
}