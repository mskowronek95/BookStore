namespace BookStore.Domain.ValueObjects;

public sealed record Money
{
    public Money(decimal amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), amount, "Amount cannot be negative.");
        }
        Amount = decimal.Round(amount, 2, MidpointRounding.AwayFromZero);
    }
    public decimal Amount { get; }
}
