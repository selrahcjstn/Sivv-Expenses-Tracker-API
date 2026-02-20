using MediatR;
using Sivv.Application.Features.UserAccounts.Commands.CreateUserAccount;
using Sivv.Application.Features.UserAccounts.Queries.GetUserByID;

namespace Sivv.Api.Endpoints
{
    public static class UserAccountEndpoint
    {
            public static void MapUserEndpoints(this IEndpointRouteBuilder app)
            {
               var group = app.MapGroup("/api/account");

                group.MapPost("/register", async (IMediator mediator, CreateUserAccountCommand command) =>
                {
                    var result = await mediator.Send(command);
                    if (result.IsSuccess)
                    {
                        return Results.Ok(result.Value);
                    }
                    else
                    {
                        return Results.BadRequest(result.ErrorMessage);
                    }
                });
               
                group.MapGet("/profile", async (Guid id, IMediator mediator) =>
                {
                    var query = new GetUserByIdQuery(id);
                    var result = await mediator.Send(query);
                    if (result.IsSuccess)
                    {
                        return Results.Ok(result.Value);
                    }
                    else
                    {
                        return Results.BadRequest(result.ErrorMessage);
                    }
                });

        }
    }
}
