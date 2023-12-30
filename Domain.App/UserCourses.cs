using System.Text.Json.Serialization;
using Domain.App.Identity;
using Domain.Base;

namespace Domain.App;

public class UserCourses : DomainEntityId
{
    public Guid AppUserId { get; set; }
    public AppUser? AppUser { get; set; } 
    public Guid CourseId { get; set; }
    public Courses? Course { get; set; }
    
}