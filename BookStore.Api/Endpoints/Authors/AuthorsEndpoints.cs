using MediatR;
using BookStore.Application.Authors.Commands.CreateAuthor;

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

        return app;
    }
}
