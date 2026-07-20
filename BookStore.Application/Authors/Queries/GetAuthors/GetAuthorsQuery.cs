using BookStore.Application.Authors.Common;
using MediatR;

namespace BookStore.Application.Authors.Queries.GetAuthors;

public sealed record GetAuthorsQuery()
    : IRequest<IReadOnlyCollection<AuthorResponse>>;
