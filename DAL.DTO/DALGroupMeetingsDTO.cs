using Domain.Base;

namespace DAL.DTO;

public class DALGroupMeetingsDTO  : DomainEntityId
{
    public Guid StudyGroupId { get; set; }
    public DALStudyGroupsDTO? StudyGroup { get; set; }
    public DateTime MeetingTime { get; set; }
    public string? MeetingLocation { get; set; }
}