using DAL.DTO.Identity;
using Domain.Base;

namespace DAL.DTO;

public class DALUserCoursesDTO : DomainEntityId
{
    public Guid AppUserId { get; set; }
    public DALAppUserDTO? AppUser { get; set; } 
    public Guid CourseId { get; set; }
    public DALCoursesDTO? Course { get; set; }
}