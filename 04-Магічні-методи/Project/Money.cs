namespace Project;

public enum Currency {
    USD,
    EUR,
    GBP,
    JPY,
    AUD,
    CAD,
    CHF,
    CNY,
    SEK,
    NZD
}

public class Money {
    public decimal Amount { get; }
    public Currency Currency { get; }

    public Money(decimal amount, Currency currency) {
        Amount = amount;
        Currency = currency;
    }

    public override int GetHashCode() => HashCode.Combine(Amount, Currency);

    public override bool Equals(object? obj) => obj is Money money && this == money;

    public static Money operator +(Money a, Money b) {
        if (a.Currency != b.Currency) {
            throw new InvalidOperationException("Cannot add amounts with different currencies.");
        }

        return new Money(a.Amount + b.Amount, a.Currency);
    }

    public static Money operator -(Money a, Money b) {
        if (a.Currency != b.Currency) {
            throw new InvalidOperationException("Cannot subtract amounts with different currencies.");
        }
        return new Money(a.Amount - b.Amount, a.Currency);
    }

    public static Money operator *(Money money, decimal multiplier) {
        return new Money(money.Amount * multiplier, money.Currency);
    }

    public static bool operator >(Money a, Money b) {
        if (a.Currency != b.Currency) {
            throw new InvalidOperationException("Cannot compare amounts with different currencies.");
        }
        return a.Amount > b.Amount;
    }

    public static bool operator <(Money a, Money b) {
        if (a.Currency != b.Currency) {
            throw new InvalidOperationException("Cannot compare amounts with different currencies.");
        }
        return a.Amount < b.Amount;
    }

    public static bool operator ==(Money a, Money b) {
        if (ReferenceEquals(a, b)) return true;
        if (a is null || b is null) return false;

        return a.Amount == b.Amount && a.Currency == b.Currency;
    }

    public static bool operator !=(Money a, Money b) => !(a == b);
}