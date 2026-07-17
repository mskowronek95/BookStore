using BookStore.Domain.ValueObjects;

namespace BookStore.Domain.Entities;

public sealed class Book
{
    public const int MaxDescriptionLength = 2000;

    private Book()
    {
    }

    public Book(Guid authorId, BookTitle title, string description, Money price, DateOnly publishedOn)
    {
        AuthorId = authorId;
        Title = title;
        SetDescription(description);
        Price = price;
        PublishedOn = publishedOn;
    }

    public Guid Id { get; private set; }
    public Guid AuthorId { get; private set; }
    public Author Author { get; private set; } = null!;
    public BookTitle Title { get; private set; } = null!;
    public string Description { get; private set; } = string.Empty;
    public Money Price { get; private set; } = null!;
    public DateOnly PublishedOn { get; private set; }
    public bool IsDeleted { get; private set; }

    private void SetDescription(string description)
    {
        if(string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentException("Book description cannot be empty.", nameof(description));
        }

        description = description.Trim();

        if (description.Length > MaxDescriptionLength)
        {
            throw new ArgumentException($"Book description cannot exceed {MaxDescriptionLength} characters.", nameof(description));
        }
        Description = description;
    }

    public void Update(
        Guid authorId,
        BookTitle title,
        string description,
        Money price,
        DateOnly publishedOn)
    {
        AuthorId = authorId;
        Title = title;
        SetDescription(description);
        Price = price;
        PublishedOn = publishedOn;
    }

    public void Delete()
    {
        IsDeleted = true;
    }
}
