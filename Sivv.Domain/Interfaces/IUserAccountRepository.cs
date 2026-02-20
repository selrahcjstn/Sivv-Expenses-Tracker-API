using Sivv.Domain.Entities;

namespace Sivv.Domain.Interfaces
{
    public interface IUserAccountRepository
    {
        Task AddAsync(UserAccount user);
        Task<UserAccount?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<UserAccount?> GetByEmailAsync(string email, CancellationToken cancellationToken);
        Task UpdateAsync(UserAccount user, CancellationToken cancellationToken);
    }
}
