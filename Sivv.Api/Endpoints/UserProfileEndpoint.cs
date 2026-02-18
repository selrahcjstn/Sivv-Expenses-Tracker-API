using MediatR;
using Sivv.Application.Features.UserProfiles.Commands.CreateUserProfile;

namespace Sivv.Api.Endpoints
{
    public static class UserProfileEndpoint
    {
        public static void MapUserProfileEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/profile");
            group.MapPost("/create", async (IMediator mediator, CreateUserProfileCommand command) =>
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
