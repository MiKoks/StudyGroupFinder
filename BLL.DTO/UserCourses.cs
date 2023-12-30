using Domain.App.Identity;
using Domain.Base;
using AppUser = BLL.DTO.Identity.AppUser;

namespace BLL.DTO;

public class UserCourses : DomainEntityId
{
    public Guid AppUserId { get; set; }
    public AppUser? AppUser { get; set; } 
    public Guid CourseId { get; set; }
    public Courses? Course { get; set; }
}