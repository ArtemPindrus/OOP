namespace Project;

public class Computer {
    public CPU Cpu { get; }
    public RAM Ram { get; }
    public Disk Disk { get; }

    public Computer(CPU cpu, RAM ram, Disk disk) {
        Cpu = cpu;
        Ram = ram;
        Disk = disk;
    }

    private IEnumerable<HardwareComponent> Parts => [Cpu, Ram, Disk];

    public decimal TotalPrice() => Parts.Sum(p => p.Price);

    public string Spec() {
        var lines = Parts.Select(p => "  " + p);

        return "Computer specification:" + Environment.NewLine +
               string.Join(Environment.NewLine, lines) + Environment.NewLine +
               $"  Total price: {TotalPrice():C}";
    }
}