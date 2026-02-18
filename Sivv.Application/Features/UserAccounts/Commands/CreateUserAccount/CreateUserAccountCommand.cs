using MediatR;
using Sivv.Application.Common.Models;

namespace Sivv.Application.Features.UserAccounts.Commands.CreateUserAccount
{
    public record CreateUserAccountCommand(
        string Username,
        string Email,
        string Password,
        string ConfirmPassword
        ) : IRequest<Result<Guid>>;
}
