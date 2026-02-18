using Sivv.Domain.Entities;

namespace Sivv.Domain.Interfaces
{
    public interface IUserAccountRepository
    {
        Task AddAsync(UserAccount user);
        Task<UserAccount?> GetByIdAsync(Guid id);
        Task<UserAccount?> GetByEmailAsync(string email);
        Task UpdateAsync(UserAccount user);
    }
}
