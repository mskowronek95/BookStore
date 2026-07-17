namespace BookStore.Domain.Entities;

public sealed class Author
{
    public const int MaxNameLength = 50;
    private Author()
    {
    }

    public Author(string firstName, string lastName)
    {
        FirstName = ValidateName(firstName, nameof(firstName));
        LastName = ValidateName(lastName, nameof(lastName));
    }

    public Guid Id { get; private set; }
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public ICollection<Book> Books { get; private set; } = [];

    private static string ValidateName(string value, string paramName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Value cannot be empty.", paramName);
        }

        value = value.Trim();

        if (value.Length > MaxNameLength)
        {
            throw new ArgumentException($"Value cannot exceed {MaxNameLength} characters.", paramName);
        }
        return value;
    }


    public void Update(
        string firstName,
        string lastName)
    {
        FirstName = ValidateName(firstName, nameof(firstName));
        LastName = ValidateName(lastName, nameof(lastName));
    }
}
