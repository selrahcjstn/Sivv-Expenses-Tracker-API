using MediatR;
using Sivv.Application.Common.Models;

namespace Sivv.Application.Features.UserAccounts.Queries.GetUserByID
{
    public record GetUserByIdQuery(Guid Id) : IRequest<Result<UserAccountDto>>;
}
