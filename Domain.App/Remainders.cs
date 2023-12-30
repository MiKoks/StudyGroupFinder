using Domain.App.Identity;
using Domain.Base;

namespace Domain.App;

public class Remainders : DomainEntityId
{
    public Guid AppUserId { get; set; }
    public AppUser? AppUser { get; set; }
    public string? Message { get; set; }
    public DateTime ReminderAt { get; set; }
}