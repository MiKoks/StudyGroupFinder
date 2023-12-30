using DAL.Contracts.App;
using DAL.Contracts.Base;

namespace BLL.Contracts.App;

public interface IRoleWithinGroupService : IBaseRepository<BLL.DTO.RoleWithinGroup>, IRoleWithinGroupRepositoryCustom<BLL.DTO.RoleWithinGroup>
{
    // add your custom service methods here
}