using BookStore.Application.Authors.Common;
using BookStore.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.Authors.Queries.GetAuthors;

public sealed class GetAuthorsQueryHandler(
    IBookStoreDbContext dbContext)
    : IRequestHandler<GetAuthorsQuery, IReadOnlyCollection<AuthorResponse>>
{
    public async Task<IReadOnlyCollection<AuthorResponse>> Handle(
        GetAuthorsQuery request,
        CancellationToken cancellationToken)
    {
        var authors = await dbContext.Authors
            .OrderBy(author => author.LastName)
            .Select(author => new AuthorResponse(
                author.Id,
                author.FirstName,
                author.LastName))
            .ToListAsync(cancellationToken);


        return authors;
    }
}
