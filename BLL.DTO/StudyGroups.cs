using System.ComponentModel.DataAnnotations;
using Domain.App.Identity;
using Domain.Base;
using AppUser = BLL.DTO.Identity.AppUser;

namespace BLL.DTO;

public class StudyGroups : DomainEntityId
{
    public Guid AppUserId { get; set; }
    public AppUser? AppUser { get; set; }
    [Display(
        Name = nameof(GroupName),
        ResourceType = typeof(App.Resources.Common))]

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
}