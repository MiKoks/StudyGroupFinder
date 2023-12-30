using Domain.App.Identity;
using Domain.Base;
using AppUser = BLL.DTO.Identity.AppUser;

namespace BLL.DTO;

public class Remainders : DomainEntityId
{
    public Guid AppUserId { get; set; }
    public AppUser? AppUser { get; set; }
    public string? Message { get; set; }
    public DateTime ReminderAt { get; set; }
}