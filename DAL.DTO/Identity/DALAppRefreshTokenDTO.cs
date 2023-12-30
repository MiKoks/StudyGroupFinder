using Domain.Base;
using Domain.Contracts.Base;

namespace DAL.DTO.Identity;

public class DALAppRefreshTokenDTO : BaseRefreshToken, IDomainEntityId
{
    public Guid AppUserId { get; set; }
    public DALAppUserDTO? AppUser { get; set; }
}