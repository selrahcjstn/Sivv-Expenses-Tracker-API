using MediatR;
using Sivv.Application.Features.UserAccounts.Commands.CreateUserAccount;

namespace Sivv.Api.Endpoints
{
    public static class UserEnpoints
    {
            public static void MapUserEndpoints(this WebApplication app)
            {
               var group = app.MapGroup("/api/users");
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
