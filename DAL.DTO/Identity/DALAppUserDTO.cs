using System.ComponentModel.DataAnnotations;
using Domain.Contracts.Base;
using Microsoft.AspNetCore.Identity;

namespace DAL.DTO.Identity;

public class DALAppUserDTO : IdentityUser<Guid>, IDomainEntityId
{

    [MaxLength(128)]
    [MinLength(1)]
    public string FirstName { get; set; } = default!;
    [MaxLength(128)]
    [MinLength(1)]
    public string LastName { get; set; } = default!;
    
    public string FullName => $"{FirstName} {LastName}";
    
    public ICollection<DALGroupMessagesDTO>? GroupMessagesCollection { get; set; }
    public ICollection<DALNotificationsDTO>? NotificationsCollection { get; set; }
    public ICollection<DALRemaindersDTO>? RemaindersCollection { get; set; }
    public ICollection<DALGroupJoinRequestsDTO>? GroupJoinRequestsCollection { get; set; }
    public ICollection<DALUserAvailabilitiesDTO>? UserAvailabilitiesCollection { get; set; }
    
    public ICollection<DALAppRefreshTokenDTO>? AppRefreshTokens { get; set; }
}