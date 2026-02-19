using Sivv.Domain.Common;

namespace Sivv.Domain.Entities
{
    public class UserAccount : BaseEntity
    {
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool IsVerified { get; set; }
        public string PasswordHash { get; set; } = null!;

        public UserProfile? UserProfile { get; set; }

        public UserAccount() { }

        public UserAccount(string username, string email, bool isVerified, string passwordHash, UserProfile? userProfile)
        {
            Username = username;
            Email = email;
            IsVerified = isVerified;
            PasswordHash = passwordHash;
            UserProfile = userProfile;
        }

         public void AttachUserProfile(UserProfile userProfile)
        {
            ArgumentNullException.ThrowIfNull(userProfile);

            UserProfile = userProfile;
            userProfile.AttachUserAccount(this);
        }
    }
}
