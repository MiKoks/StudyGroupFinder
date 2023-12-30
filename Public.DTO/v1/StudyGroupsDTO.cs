namespace Public.DTO.v1;

public class StudyGroupsDTO
{
    public Guid Id { get; set; }
    public string? GroupName { get; set; }
    public string? Description { get; set; }
    public string? MeetingTimes { get; set; }
    public string? Location { get; set; }
    public Guid CourseId { get; set; }
    public int MaxGroupSize { get; set; }
    public DateTime CreatedAt { get; set; }
}