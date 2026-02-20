namespace Sivv.Application.Features.UserAccounts.Queries.GetUserByID
{
    public record UserAccountDto(
     Guid Id,              
     string Username,
     string Email,
     bool IsVerified,
     DateTime CreatedAt,
     DateTime? UpdatedAt
 );
}
