using FluentValidation;
using BookStore.Domain.Entities;

namespace BookStore.Application.Authors.Commands.CreateAuthor.Validators;

public sealed class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
{
    public CreateAuthorCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(Author.MaxNameLength);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(Author.MaxNameLength);
    }
}
