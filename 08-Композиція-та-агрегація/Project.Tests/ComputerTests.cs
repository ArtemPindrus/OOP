namespace Project.Tests;

public class ComputerTests {
    [Fact]
    public void TotalPrice_is_correct() {
        CPU cpu = new("Ryzen 5", "Cores: 6; Frequency: 2.1GHz", 120);
        RAM ram = new("Crucial", "Type: DD4; Size: 16Gb", 200);
        Disk disk = new("WD", "Storage: 1TB", 210);
        decimal expected = 530;

        Computer sut = new(cpu, ram, disk);
        decimal actual = sut.TotalPrice();

        Assert.Equal(expected, actual);
    }
}