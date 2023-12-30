using DAL.DTO.Identity;
using Domain.Base;

namespace DAL.DTO;

public class DALNotificationsDTO : DomainEntityId
{
    public Guid UserId { get; set; }
    public DALAppUserDTO? User { get; set; }
    public string? Message { get; set; }
    public DateTime CreatedAt { get; set; }
}