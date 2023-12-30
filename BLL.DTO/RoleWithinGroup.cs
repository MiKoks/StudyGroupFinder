using Domain.Base;

namespace BLL.DTO;

public class RoleWithinGroup : DomainEntityId
{
    public string? RoleName { get; set; }
    
    public ICollection<UserStudyGroups>? UserStudyGroupsCollection { get; set; }
}