using BookStore.Application.Authors.Common;
using BookStore.Application.Common.Exceptions;
using BookStore.Application.Common.Interfaces;
using BookStore.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.Authors.Queries.GetAuthorById;

public sealed class GetAuthorByIdQueryHandler(
    IBookStoreDbContext dbContext)
    : IRequestHandler<GetAuthorByIdQuery, AuthorResponse>
{
    public async Task<AuthorResponse> Handle(
        GetAuthorByIdQuery request,
        CancellationToken cancellationToken)
    {
        var author = await dbContext.Authors
            .Where(author => author.Id == request.Id)
            .Select(author => new AuthorResponse(
                author.Id,
                author.FirstName,
                author.LastName
                ))
            .FirstOrDefaultAsync(cancellationToken);
            
        if (author is null)
        {
            throw new NotFoundException(nameof(Author), request.Id);
        }

        return author;
    }
}
