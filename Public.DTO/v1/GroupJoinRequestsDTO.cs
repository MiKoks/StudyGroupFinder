namespace Public.DTO.v1;

public class GroupJoinRequestsDTO
{
    public Guid Id { get; set; }
    public bool RequestStatus { get; set; }
    public DateTime RequestedAt { get; set; }
}