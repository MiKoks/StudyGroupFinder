using Domain.App.Identity;
using Domain.Base;
using AppUser = BLL.DTO.Identity.AppUser;

namespace BLL.DTO;

public class UserStudyGroups : DomainEntityId
{
    public Guid AppUserId { get; set; }
    public AppUser? AppUser { get; set; }
    public Guid? StudyGroupsId { get; set; }
    public StudyGroups? StudyGroups { get; set; }
    public DateTime JoinedAt { get; set; }
    public Guid RoleWithinGroupId { get; set; }
    public RoleWithinGroup? RoleWithinGroup { get; set; }
}