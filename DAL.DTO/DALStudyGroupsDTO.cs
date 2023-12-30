using DAL.DTO.Identity;
using Domain.Base;

namespace DAL.DTO;

public class DALStudyGroupsDTO : DomainEntityId
{
    public Guid AppUserId { get; set; }
    public DALAppUserDTO? AppUser { get; set; }
    public string? GroupName { get; set; }
    public string? Description { get; set; }
    public Guid CourseId { get; set; }
    public DALCoursesDTO? Course { get; set; }
    public string? MeetingTimes { get; set; }
    public string? Location { get; set; }
    public int MaxGroupSize { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public ICollection<DALGroupMeetingsDTO>? GroupMeetingsCollection { get; set; }
    public ICollection<DALGroupJoinRequestsDTO>? GroupJoinRequestsCollection { get; set; }
    public ICollection<DALGroupMessagesDTO>? GroupMessagesCollection { get; set; }
}