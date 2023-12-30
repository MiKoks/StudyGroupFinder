using Domain.Contracts.Base;
using Microsoft.AspNetCore.Identity;

namespace BLL.DTO.Identity;

public class AppRole : IdentityRole<Guid>, IDomainEntityId
{
    
}