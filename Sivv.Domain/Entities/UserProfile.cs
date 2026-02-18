using Sivv.Domain.Common;

namespace Sivv.Domain.Entities
{
    public class UserProfile : BaseEntity
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime BirthDate { get; set; }

        public Guid UserAccountId { get; set; } // FK
        public UserAccount UserAccount { get; set; } = null!; // Navigation property for user account

        public UserProfile() { }

        public UserProfile(string firstName, string lastName, string birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = DateTime.Parse(birthDate);
        }
    }
}
