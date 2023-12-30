using DAL.Contracts.Base;
using DAL.DTO;
using Domain.App;

namespace DAL.Contracts.App;

public interface IStudyGroupsRepository : IBaseRepository<DALStudyGroupsDTO>, IStudyGroupsRepositoryCustom<DALStudyGroupsDTO>
{
    // add here custom methods for repo only
    
    
}

public interface IStudyGroupsRepositoryCustom<TEntity>
{
    // add here shared custom methods between repo and service that are not in IBaseRepository
}