using DAL.Contracts.Base;
using DAL.DTO;
using Domain.App;

namespace DAL.Contracts.App;

public interface INotificationsRepository : IBaseRepository<DALNotificationsDTO>, INotificationsRepositoryCustom<DALNotificationsDTO>
{
    // add here custom methods for repo only
}

public interface INotificationsRepositoryCustom<TEntity>
{
    // add here shared custom methods between repo and service that are not in IBaseRepository
}