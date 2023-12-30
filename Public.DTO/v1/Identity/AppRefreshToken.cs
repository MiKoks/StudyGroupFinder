using Domain.Base;
using Domain.Contracts.Base;
using BLL.DTO.Identity;

namespace Public.DTO.v1.Identity;

public class AppRefreshToken : BaseRefreshToken, IDomainEntityId
{
    /// <summary>
    /// Reference to the user who owns this refresh token
    /// </summary>
    public Guid AppUserId { get; set; }
}