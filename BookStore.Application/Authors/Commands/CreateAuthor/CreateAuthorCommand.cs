using MediatR;

namespace BookStore.Application.Authors.Commands.CreateAuthor;

public sealed record CreateAuthorCommand(
    string FirstName,
    string LastName)
    : IRequest<Guid>;