using FluentValidation;
using MediatR;
using Sivv.Application.Common.Models;
using Sivv.Domain.Entities;
using Sivv.Domain.Interfaces;

namespace Sivv.Application.Features.UserProfiles.Commands.CreateUserProfile
{
    public class CreateUserProfileHandler : IRequestHandler<CreateUserProfileCommand, Result<Guid>>
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IValidator<CreateUserProfileCommand> _validator;

        public CreateUserProfileHandler(IUserProfileRepository userProfileRepository, IValidator<CreateUserProfileCommand> validator)
        {
            _userProfileRepository = userProfileRepository;
            _validator = validator;
        }

        public async Task<Result<Guid>> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                var errorMessage = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
                return await Task.FromResult(Result<Guid>.Failure(errorMessage));
            }

            var userProfile = new UserProfile
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                BirthDate = request.BirthDate
            };

            await _userProfileRepository.AddAsync(userProfile, cancellationToken);
            return Result<Guid>.Success(userProfile.Id);
        }
    }
}
