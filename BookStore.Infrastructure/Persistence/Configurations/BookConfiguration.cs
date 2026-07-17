using BookStore.Domain.Entities;
using BookStore.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infrastructure.Persistence.Configurations;

public sealed class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books");

        builder.HasKey(book => book.Id);

        builder.Property(book => book.Title)
            .HasConversion(
                title => title.Value,
                value => new BookTitle(value))
            .HasMaxLength(BookTitle.MaxLength)
            .IsRequired();

        builder.Property(book => book.Description)
            .HasMaxLength(Book.MaxDescriptionLength)
            .IsRequired();

        builder.Property(book => book.Price)
            .HasConversion(
                money => money.Amount,
                value => new Money(value))
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(book => book.PublishedOn)
            .IsRequired();

        builder.Property(book => book.IsDeleted)
            .HasDefaultValue(false)
            .IsRequired();
    }
}
