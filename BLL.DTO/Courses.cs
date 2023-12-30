using Domain.Base;

namespace BLL.DTO;

public class Courses : DomainEntityId
{
    public string? CourseName { get; set; }
    public string? CourseCode { get; set; }
    
    public ICollection<StudyGroups>? StudyGroupsCollection { get; set; }
}