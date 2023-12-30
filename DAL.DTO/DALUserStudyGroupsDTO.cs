using DAL.DTO.Identity;
using Domain.Base;

namespace DAL.DTO;

public class DALUserStudyGroupsDTO : DomainEntityId
{
    public Guid AppUserId { get; set; }
    public DALAppUserDTO? AppUser { get; set; }
    public Guid? StudyGroupsId { get; set; }
    public DALStudyGroupsDTO? StudyGroups { get; set; }
    public DateTime JoinedAt { get; set; }
    public Guid RoleWithinGroupId { get; set; }
    public DALRoleWithinGroupDTO? RoleWithinGroup { get; set; }
}