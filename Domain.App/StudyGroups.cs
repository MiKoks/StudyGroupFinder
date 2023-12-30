using System.Collections;
using System.Text.Json.Serialization;
using Domain.App.Identity;
using Domain.Base;

namespace Domain.App;

public class StudyGroups : DomainEntityId
{
    public Guid AppUserId { get; set; }
    public AppUser? AppUser { get; set; }
    public string? GroupName { get; set; }
    public string? Description { get; set; }
    public Guid CourseId { get; set; }
    public Courses? Course { get; set; }
    public string? MeetingTimes { get; set; }
    public string? Location { get; set; }
    public int MaxGroupSize { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public ICollection<GroupMeetings>? GroupMeetingsCollection { get; set; }
    public ICollection<GroupJoinRequests>? GroupJoinRequestsCollection { get; set; }
    public ICollection<GroupMessages>? GroupMessagesCollection { get; set; }
    
    // lisada
    
    //public ICollection<AppUser>? GroupMembers { get; set; }
}