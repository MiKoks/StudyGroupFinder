using Domain.Base;

namespace Public.DTO.v1;

public class AppRefreshToken : BaseRefreshToken
{
    public AppUser? AppUser { get; set; }
    public Guid AppUserId { get; set; }
}