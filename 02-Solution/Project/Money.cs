namespace Project;

public class Money {
    public int AmountInCoins { get; }

    public Money(int amountInCoins) {
        AmountInCoins = amountInCoins;
    }

    public static Money FromFloat(float amount) {
        return new Money((int)amount * 100);
    }

    /// <summary>
    /// Returns <see cref="Money"/> instance given string representing money in UAH. (12.5)
    /// </summary>
    /// <exception cref="ArgumentException">Invalid string format.</exception>
    public static Money FromString(string money) {
        money = money.Replace('.', ',');

        if (float.TryParse(money, out float result)) {
            int amountInCoins = (int)(result * 10);
            return new Money(amountInCoins);
        } else {
            throw new ArgumentException("Invalid amount format");
        }
    }

    public float ToFloat() {
        return AmountInCoins / 100.0f;
    }

    public override string ToString() => $"{ToFloat():0.00} UAH".Replace(',', '.');
}