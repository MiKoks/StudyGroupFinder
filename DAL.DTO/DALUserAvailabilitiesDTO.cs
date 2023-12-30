using DAL.DTO.Identity;
using Domain.Base;

namespace DAL.DTO;

public class DALUserAvailabilitiesDTO : DomainEntityId
{
    public Guid UserId { get; set; }
    public DALAppUserDTO? User { get; set; }
    public DateTime AvailabilityTimes { get; set; }
}