using DAL.Contracts.Base;
using DAL.DTO;
using Domain.App;

namespace DAL.Contracts.App;

public interface IGroupJoinRequestsRepository : IBaseRepository<DALGroupJoinRequestsDTO>, IGroupJoinRequestsRepositoryCustom<DALGroupJoinRequestsDTO>
{
    // add here custom methods for repo only
}

public interface IGroupJoinRequestsRepositoryCustom<TEntity>
{
    // add here shared custom methods between repo and service that are not in IBaseRepository
    
    Task<IEnumerable<TEntity>> AllAsync(Guid userId);
    
    Task<TEntity?> FindAsync(Guid id, Guid userId);
    Task<TEntity?> RemoveAsync(Guid id, Guid userId);
    Task<bool> IsOwnedByUserAsync(Guid id, Guid userId);
}