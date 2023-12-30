using Domain.Base;

namespace DAL.DTO;

public class DALRoleWithinGroupDTO  : DomainEntityId
{
    public string? RoleName { get; set; }
    
    public ICollection<DALUserStudyGroupsDTO>? UserStudyGroupsCollection { get; set; }
}