using DAL.DTO.Identity;
using Domain.Base;

namespace DAL.DTO;

public class DALRemaindersDTO : DomainEntityId
{
    public Guid AppUserId { get; set; }
    public DALAppUserDTO? AppUser { get; set; }
    public string? Message { get; set; }
    public DateTime ReminderAt { get; set; }
}