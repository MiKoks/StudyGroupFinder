using Domain.App.Identity;
using Domain.Base;

namespace Domain.App;

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