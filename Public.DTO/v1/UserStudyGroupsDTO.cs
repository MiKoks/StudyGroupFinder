namespace Public.DTO.v1;

public class UserStudyGroupsDTO
{
    public Guid Id { get; set; }
    public DateTime JoinedAt { get; set; }
    public Guid RoleWithinGroupId { get; set; }
}