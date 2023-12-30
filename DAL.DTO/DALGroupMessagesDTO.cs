using DAL.DTO.Identity;
using Domain.Base;

namespace DAL.DTO;

public class DALGroupMessagesDTO : DomainEntityId
{
    public Guid StudyGroupId { get; set; }
    public DALStudyGroupsDTO? StudyGroup { get; set; }
    public Guid SenderUserId { get; set; }
    public DALAppUserDTO? SenderUser { get; set; }
    
    public string? Message { get; set; }
    
    public DateTime TimeStamp { get; set; }
}