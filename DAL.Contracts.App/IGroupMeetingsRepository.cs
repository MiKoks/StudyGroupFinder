using DAL.Contracts.Base;
using DAL.DTO;
using Domain.App;

namespace DAL.Contracts.App;

public interface IGroupMeetingsRepository : IBaseRepository<DALGroupMeetingsDTO>, IGroupMeetingsRepositoryCustom<DALGroupMeetingsDTO>
{
    // add here custom methods for repo only
}

public interface IGroupMeetingsRepositoryCustom<TEntity>
{
    // add here shared custom methods between repo and service that are not in IBaseRepository
    Task<IEnumerable<TEntity>> AllAsync(Guid userId);
}