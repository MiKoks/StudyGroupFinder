using Domain.Base;

namespace BLL.DTO;

public class GroupMeetings : DomainEntityId
{
    public Guid StudyGroupId { get; set; }
    public StudyGroups? StudyGroup { get; set; }
    public DateTime MeetingTime { get; set; }
    public string? MeetingLocation { get; set; }
}