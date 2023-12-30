namespace Public.DTO.v1;

public class RemaindersDTO
{
    public Guid Id { get; set; }
    public string? Message { get; set; }
    public DateTime ReminderAt { get; set; }
}