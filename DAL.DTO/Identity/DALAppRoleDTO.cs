using Domain.Contracts.Base;
using Microsoft.AspNetCore.Identity;

namespace DAL.DTO.Identity;

public class DALAppRoleDTO : IdentityRole<Guid>, IDomainEntityId
{
    
}