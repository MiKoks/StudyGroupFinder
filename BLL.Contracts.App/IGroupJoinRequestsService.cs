using DAL.Contracts.App;
using DAL.Contracts.Base;

namespace BLL.Contracts.App;

public interface IGroupJoinRequestsService : IBaseRepository<BLL.DTO.GroupJoinRequests>, IGroupJoinRequestsRepositoryCustom<BLL.DTO.GroupJoinRequests>
{
    // add your custom service methods here
}
