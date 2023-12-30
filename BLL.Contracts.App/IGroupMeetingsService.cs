using DAL.Contracts.App;
using DAL.Contracts.Base;

namespace BLL.Contracts.App;

public interface IGroupMeetingsService : IBaseRepository<BLL.DTO.GroupMeetings>, IGroupMeetingsRepositoryCustom<BLL.DTO.GroupMeetings>
{
    // add your custom service methods here
}