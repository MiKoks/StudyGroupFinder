using System.ComponentModel.DataAnnotations;
using Domain.Contracts.Base;
using Microsoft.AspNetCore.Identity;

namespace Public.DTO.v1;

public class AppUser : IdentityUser<Guid> , IDomainEntityId
{
    [MaxLength(128)]
    public string FirstName { get; set; } = default!;

    [MaxLength(128)]
    public string LastName { get; set; } = default!;
    
    public string FullName => $"{FirstName} {LastName}";

    //public ICollection<>
    public ICollection<AppRefreshToken>? AppRefreshTokens { get; set; }
}