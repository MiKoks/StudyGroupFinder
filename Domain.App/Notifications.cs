using Domain.App.Identity;
using Domain.Base;

namespace Domain.App;

public class Notifications : DomainEntityId
{
    public Guid UserId { get; set; }
    public AppUser? User { get; set; }
    public string? Message { get; set; }
    public DateTime CreatedAt { get; set; }
}