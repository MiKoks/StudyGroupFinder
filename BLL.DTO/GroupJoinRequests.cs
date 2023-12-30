using Domain.App.Identity;
using Domain.Base;
using AppUser = BLL.DTO.Identity.AppUser;

namespace BLL.DTO;

public class GroupJoinRequests : DomainEntityId
{ 
    public Guid StudyGroupsId { get; set; }
    public StudyGroups? StudyGroups { get; set; }
    public Guid SenderUserId { get; set; }
    public AppUser? SenderUser { get; set; }
    public bool RequestStatus { get; set; }
    public DateTime RequestedAt { get; set; }
}