using FluentValidation;
using MediatR;
using Sivv.Application.Common.Models;
using Sivv.Domain.Entities;
using Sivv.Domain.Interfaces;

namespace Sivv.Application.Features.UserAccounts.Commands.CreateUserAccount
{
    public class CreateUserAccountHandler
        : IRequestHandler<CreateUserAccountCommand, Result<Guid>>
    {
        private readonly IUserAccountRepository _userRepository;
        private readonly IValidator<CreateUserAccountCommand> _validator;

        public CreateUserAccountHandler(IUserAccountRepository userRepository, IValidator<CreateUserAccountCommand> validator)
        {
            _userRepository = userRepository;
            _validator = validator;
        }

        public async Task<Result<Guid>> Handle(
            CreateUserAccountCommand request,
            CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return Result<Guid>.Failure(validationResult.Errors[0].ErrorMessage);
            }

            var existingUser =
                await _userRepository.GetByEmailAsync(request.Email, cancellationToken);

            if (existingUser != null)
            {
                return Result<Guid>.Failure("A user with this email already exists.");
            }

            var newUser = new UserAccount
            {
                Id = Guid.NewGuid(),
                Username = request.Username,
                Email = request.Email,
                PasswordHash = request.Password,
            };

            await _userRepository.AddAsync(newUser);

            return Result<Guid>.Success(newUser.Id);
        }
    }
}