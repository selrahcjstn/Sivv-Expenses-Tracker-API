using Sivv.Domain.Entities;

namespace Sivv.Domain.Interfaces
{
    public interface IUserProfileRepository
    {
        Task AddAsync(UserProfile userProfile, CancellationToken cancellationToken);
        Task<UserProfile?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task UpdateAsync(UserProfile userProfile, CancellationToken cancellationToken);
    }
}
