using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodStore.Domain.Valueobjects;

public class Money : ValueObject
{
    public decimal Amount { get; }
    public string Currency { get; }
    public Money(decimal amount, string currency = "USD")
    {
        if (amount < 0)
            throw new ArgumentOutOfRangeException(nameof(ArgumentOutOfRangeException), "Money amount cannot be negative");
        Amount = amount;
        Currency = currency;
    }
    public static Money operator +(Money a, Money b)
    {
        if (a.Currency != b.Currency)
            throw new InvalidOperationException("Cannot add money values with different currencies.");
        return new Money(a.Amount + b.Amount, a.Currency);
    }
    public static Money operator -(Money a, Money b)
    {
        if (a.Currency != b.Currency)
            throw new InvalidOperationException("Cannot add money values with different currencies.");

        return new Money(Math.Abs(a.Amount - b.Amount), a.Currency);
    }
    public static Money operator *(Money money, int multiplier)
    => new Money(money.Amount * multiplier, money.Currency);
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return new object[] { Amount, Currency };
    }
}
