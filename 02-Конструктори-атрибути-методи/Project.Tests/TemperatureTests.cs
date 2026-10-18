namespace Project.Tests;

public class TemperatureTests {
    [TestCase(100, 37.77778)]
    [TestCase(0, -17.77778)]
    [TestCase(120, 48.88889)]
    [TestCase(-50, -45.55556)]
    public void FromFahrenheit_ConvertsToCorrectCelcius(double fahrenheit, double expectedCelsius) {
        Temperature t = Temperature.FromFahrenheit(fahrenheit);

        double actual = t.Celsius;

        Assert.That(actual, Is.EqualTo(expectedCelsius).Within(0.01));
    }

    [TestCase(0, -273.15)]
    [TestCase(100, -173.15)]
    [TestCase(120, -153.15)]
    [TestCase(300, 26.85)]
    [TestCase(-50, -323.15)]
    public void FromKelvin_ConvertsToCorrectCelcius(double kelvin, double expectedCelsius) {
        Temperature t = Temperature.FromKelvin(kelvin);

        double actual = t.Celsius;

        Assert.That(actual, Is.EqualTo(expectedCelsius).Within(0.01));
    }

    [TestCase(37.77778, 100)]
    [TestCase(-17.77778, 0)]
    [TestCase(48.88889, 120)]
    [TestCase(-45.55556, -50)]
    public void ToFahrenheit_ReturnsCorrectValue(double celcius, double expectedFahreiheit) {
        Temperature t = new(celcius);

        double actual = t.ToFahrenheit();

        Assert.That(actual, Is.EqualTo(expectedFahreiheit).Within(0.01));
    }
}