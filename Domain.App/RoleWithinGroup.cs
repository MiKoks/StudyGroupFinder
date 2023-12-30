using Domain.Base;

namespace Domain.App;

public class RoleWithinGroup  : DomainEntityId
{
    public string? RoleName { get; set; }
    
    public ICollection<UserStudyGroups>? UserStudyGroupsCollection { get; set; }
}