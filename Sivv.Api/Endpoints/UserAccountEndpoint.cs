using MediatR;
using Sivv.Application.Features.UserAccounts.Commands.CreateUserAccount;

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

        }
    }
}
