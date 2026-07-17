using BookStore.Application.Common.Interfaces;
using MediatR;
using BookStore.Domain.Entities;

namespace BookStore.Application.Authors.Commands.CreateAuthor;

public sealed class CreateAuthorCommandHandler(
    IBookStoreDbContext dbContext)
    : IRequestHandler<CreateAuthorCommand, Guid>
{
    public async Task<Guid> Handle(
        CreateAuthorCommand command,
        CancellationToken cancellationToken)
    {
        var author = new Author(command.FirstName, command.LastName);

        await dbContext.Authors.AddAsync(
            author,
            cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);

        return author.Id;
    }
}
