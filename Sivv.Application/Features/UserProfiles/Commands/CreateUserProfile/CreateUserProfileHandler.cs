using FluentValidation;
using MediatR;
using Sivv.Application.Common.Models;
using Sivv.Application.Features.UserProfiles.Commands.CreateUserProfile;
using Sivv.Domain.Entities;
using Sivv.Domain.Interfaces;

public class CreateUserProfileHandler
    : IRequestHandler<CreateUserProfileCommand, Result<Guid>>
{
    private readonly IUserAccountRepository _userRepository;
    private readonly IUserProfileRepository _userProfileRepository;
    private readonly IValidator<CreateUserProfileCommand> _validator;

    public CreateUserProfileHandler(
        IUserAccountRepository userRepository,
        IUserProfileRepository userProfileRepository,
        IValidator<CreateUserProfileCommand> validator)
    {
        _userRepository = userRepository;
        _userProfileRepository = userProfileRepository;
        _validator = validator;
    }

    public async Task<Result<Guid>> Handle(
        CreateUserProfileCommand request,
        CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errorMessage = string.Join("; ",
                validationResult.Errors.Select(e => e.ErrorMessage));

            return Result<Guid>.Failure(errorMessage);
        }

        var userAccount = await _userRepository
            .GetByIdAsync(request.UserId, cancellationToken);

        if (userAccount is null)
            return Result<Guid>.Failure("User not found");

        var userProfile = new UserProfile(
            request.FirstName,
            request.LastName,
            request.BirthDate
        );

        userAccount.AttachUserProfile(userProfile);

        await _userProfileRepository.AddAsync(userProfile, cancellationToken);

        return Result<Guid>.Success(userProfile.Id);
    }
}