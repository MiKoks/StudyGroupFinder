using System.ComponentModel.DataAnnotations;
using Domain.Contracts.Base;
using Microsoft.AspNetCore.Identity;

namespace Domain.App.Identity;

public class AppUser : IdentityUser<Guid>, IDomainEntityId
{

    [MaxLength(128)]
    [MinLength(1)]
    public string FirstName { get; set; } = default!;
    [MaxLength(128)]
    [MinLength(1)]
    public string LastName { get; set; } = default!;
    
    public string FullName => $"{FirstName} {LastName}";
    
    public ICollection<GroupMessages>? GroupMessagesCollection { get; set; }
    public ICollection<Notifications>? NotificationsCollection { get; set; }
    public ICollection<Remainders>? RemaindersCollection { get; set; }
    public ICollection<GroupJoinRequests>? GroupJoinRequestsCollection { get; set; }
    public ICollection<UserAvailabilities>? UserAvailabilitiesCollection { get; set; }
    
    public ICollection<AppRefreshToken>? AppRefreshTokens { get; set; }
}