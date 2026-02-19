using FluentValidation;
using MediatR;
using Sivv.Application.Common.Models;
using Sivv.Domain.Entities;
using Sivv.Domain.Interfaces;

namespace Sivv.Application.Features.UserProfiles.Commands.CreateUserProfile
{
    public class CreateUserProfileHandler(IUserProfileRepository userProfileRepository, IUserAccountRepository userAccountRepository, IValidator<CreateUserProfileCommand> validator) : IRequestHandler<CreateUserProfileCommand, Result<Guid>>
    {
        private readonly IUserProfileRepository _userProfileRepository = userProfileRepository;
        private readonly IUserAccountRepository _userAccountRepository = userAccountRepository;
        private readonly IValidator<CreateUserProfileCommand> _validator = validator;

        public async Task<Result<Guid>> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                var errorMessage = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
                return await Task.FromResult(Result<Guid>.Failure(errorMessage));
            }

            var user = await _userAccountRepository.GetByIdAsync(request.UserId);
            if (user == null)
            {
                return await Task.FromResult(Result<Guid>.Failure("User doesn't exist, create account first."));
            }

            var userProfile = new UserProfile
            (
                request.FirstName,
                request.LastName,
                request.BirthDate
            );

            user.AttachUserProfile(userProfile);

            await _userProfileRepository.AddAsync(userProfile, cancellationToken);
            return Result<Guid>.Success(userProfile.Id);
        }
    }
}
