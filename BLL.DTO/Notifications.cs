using Domain.App.Identity;
using Domain.Base;

namespace BLL.DTO;

public class Notifications : DomainEntityId
{
    public Guid UserId { get; set; }
    public AppUser? User { get; set; }
    public string? Message { get; set; }
    public DateTime CreatedAt { get; set; }
}