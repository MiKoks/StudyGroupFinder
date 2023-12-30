using Domain.App.Identity;
using Domain.Base;

namespace Domain.App;

public class GroupMessages : DomainEntityId
{
    public Guid StudyGroupId { get; set; }
    public StudyGroups? StudyGroup { get; set; }
    public Guid SenderUserId { get; set; }
    public AppUser? SenderUser { get; set; }
    
    public string? Message { get; set; }
    
    public DateTime TimeStamp { get; set; }
}