using MediatR;
using Sivv.Application.Common.Models;

namespace Sivv.Application.Features.UserProfiles.Commands.CreateUserProfile
{
    public record CreateUserProfileCommand(
        Guid UserId,
        string FirstName,
        string LastName,
        DateOnly BirthDate
     ) : IRequest<Result<Guid>>;
}
