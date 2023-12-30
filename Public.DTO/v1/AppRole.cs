using Domain.Contracts.Base;
using Microsoft.AspNetCore.Identity;

namespace Public.DTO.v1;

public class AppRole : IdentityRole<Guid>, IDomainEntityId
{
    
}