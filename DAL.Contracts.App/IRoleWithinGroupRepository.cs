using DAL.Contracts.Base;
using DAL.DTO;
using DAL.DTO.Identity;
using Domain.App;

namespace DAL.Contracts.App;

public interface IRoleWithinGroupRepository : IBaseRepository<DALRoleWithinGroupDTO>, IRoleWithinGroupRepositoryCustom<DALRoleWithinGroupDTO>
{
    // add here custom methods for repo only
}

public interface IRoleWithinGroupRepositoryCustom<TEntity>
{
    // add here shared custom methods between repo and service that are not in IBaseRepository
}