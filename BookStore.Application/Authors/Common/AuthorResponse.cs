namespace BookStore.Application.Authors.Common;

public sealed record AuthorResponse(
    Guid Id,
    string FirstName,
    string LastName);