namespace Public.DTO.v1;

public class NotificationsDTO
{
    public Guid Id { get; set; }
    public string? Message { get; set; }
    public DateTime CreatedAt { get; set; }
}