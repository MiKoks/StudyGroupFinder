namespace Public.DTO.v1;

public class GroupMeetingsDTO
{
    public Guid Id { get; set; }
    public DateTime MeetingTime { get; set; }
    public string? MeetingLocation { get; set; }
}