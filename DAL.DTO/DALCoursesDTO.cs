using Domain.Base;

namespace DAL.DTO;

public class DALCoursesDTO : DomainEntityId
{
    public string? CourseName { get; set; }
    public string? CourseCode { get; set; }
    
    public ICollection<DALStudyGroupsDTO>? StudyGroupsCollection { get; set; }
}