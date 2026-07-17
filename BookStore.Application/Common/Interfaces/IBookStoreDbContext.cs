using Microsoft.EntityFrameworkCore;
using BookStore.Domain.Entities;

namespace BookStore.Application.Common.Interfaces;

public interface IBookStoreDbContext
{
    DbSet<Author> Authors { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
