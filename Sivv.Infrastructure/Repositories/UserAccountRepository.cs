using Microsoft.EntityFrameworkCore;
using Sivv.Domain.Entities;
using Sivv.Domain.Interfaces;
using Sivv.Infrastructure.Data;

namespace Sivv.Infrastructure.Repositories
{
    public class UserAccountRepository : IUserAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public UserAccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(UserAccount user)
        {
           await _context.UserAccounts.AddAsync(user);
           await _context.SaveChangesAsync();
        }

        public Task<UserAccount?> GetByEmailAsync(string email)
        {
            return _context.UserAccounts
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<UserAccount?> GetByIdAsync(Guid id)
        {
            return await _context.UserAccounts
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task UpdateAsync(UserAccount user)
        {
            _context.UserAccounts.Update(user);

            await _context.SaveChangesAsync();
        }
    }
}
