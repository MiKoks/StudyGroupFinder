using Domain.App.Identity;
using Domain.Base;

namespace BLL.DTO;

public class UserAvailabilities : DomainEntityId
{
    public Guid UserId { get; set; }
    public AppUser? User { get; set; }
    public DateTime AvailabilityTimes { get; set; }
}