using MediatR;
using BookStore.Application.Authors.Commands.CreateAuthor;
using BookStore.Application.Authors.Queries.GetAuthors;
using BookStore.Application.Authors.Common;
using BookStore.Application.Authors.Queries.GetAuthorById;

namespace BookStore.Api.Endpoints.Authors;

public static class AuthorsEndpoints
{
    public static IEndpointRouteBuilder MapAuthorEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/authors", async(
            CreateAuthorCommand command,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var authorId = await sender.Send(command, cancellationToken);

            return Results.Created($"/authors/{authorId}", authorId);
        });

        app.MapGet("/authors", async(
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var authors = await sender.Send(new GetAuthorsQuery(), cancellationToken);

            return Results.Ok(authors);
        });

        app.MapGet("/authors/{id}", async(
            Guid id,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var author = await sender.Send(new GetAuthorByIdQuery(id), cancellationToken);

            return Results.Ok(author);
        });

        return app;
    }
}
