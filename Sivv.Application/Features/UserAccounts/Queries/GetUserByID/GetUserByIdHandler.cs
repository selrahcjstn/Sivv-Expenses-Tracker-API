using MediatR;
using Sivv.Application.Common.Models;
using Sivv.Domain.Interfaces;

namespace Sivv.Application.Features.UserAccounts.Queries.GetUserByID
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, Result<UserAccountDto>>
    {
        private readonly IUserAccountRepository _userAccountRepository;

        public GetUserByIdHandler(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        public async Task<Result<UserAccountDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var userAccount = await _userAccountRepository.GetByIdAsync(request.Id, cancellationToken);
            if (userAccount == null)
            {
                return Result<UserAccountDto>.Failure("User account not found.");
            }
            var userAccountDto = new UserAccountDto(
                userAccount.Id,
                userAccount.Username,
                userAccount.Email,
                userAccount.IsVerified,
                userAccount.CreatedAt,
                userAccount .UpdatedAt
            );

            return Result<UserAccountDto>.Success(userAccountDto);
        }
    }
}
