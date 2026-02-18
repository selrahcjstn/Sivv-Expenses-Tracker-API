using Sivv.Domain.Entities;
using Sivv.Domain.Interfaces;
using Sivv.Infrastructure.Data;

namespace Sivv.Infrastructure.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly ApplicationDbContext _context;

        public UserProfileRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(UserProfile userProfile, CancellationToken cancellationToken)
        {
            await _context.UserProfiles.AddAsync(userProfile, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<UserProfile?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.UserProfiles.FindAsync([id], cancellationToken: cancellationToken);
        }

        public Task UpdateAsync(UserProfile userProfile, CancellationToken cancellationToken)
        {
            _context.UserProfiles.Update(userProfile);
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
