using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Domain.Base;

namespace Domain.App;

public class Courses : DomainEntityId
{
    [Display(Name = "Course name")]
    public string? CourseName { get; set; }
    public string? CourseCode { get; set; }
    
    public ICollection<StudyGroups>? StudyGroupsCollection { get; set; }
}