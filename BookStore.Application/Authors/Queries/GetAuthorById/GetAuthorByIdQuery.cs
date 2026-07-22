using BookStore.Application.Authors.Common;
using MediatR;

namespace BookStore.Application.Authors.Queries.GetAuthorById;

public sealed record GetAuthorByIdQuery(Guid Id)
    : IRequest<AuthorResponse>;
