using DAL.DTO.Identity;
using Domain.Base;

namespace DAL.DTO;

public class DALGroupJoinRequestsDTO  : DomainEntityId
{
    public Guid StudyGroupsId { get; set; }
    public DALStudyGroupsDTO? StudyGroups { get; set; }
    public Guid SenderUserId { get; set; }
    public DALAppUserDTO? SenderUser { get; set; }
    public bool RequestStatus { get; set; }
    public DateTime RequestedAt { get; set; }
}