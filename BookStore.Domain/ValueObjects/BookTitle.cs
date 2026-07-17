namespace BookStore.Domain.ValueObjects;

public sealed record BookTitle
{
    public const int MaxLength = 100;
    public BookTitle(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Book title cannot be empty.", nameof(value));
        }

        value = value.Trim();

        if (value.Length > MaxLength)
        {
            throw new ArgumentException($"Title cannot exceed {MaxLength} characters.", nameof(value));
        }

        Value = value;
    }
        public string Value { get; }
}
