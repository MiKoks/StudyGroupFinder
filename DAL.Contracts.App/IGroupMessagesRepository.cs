using DAL.Contracts.Base;
using DAL.DTO;
using Domain.App;

namespace DAL.Contracts.App;

public interface IGroupMessagesRepository : IBaseRepository<DALGroupMessagesDTO>, IGroupMessagesRepositoryCustom<DALGroupMessagesDTO>
{
    // add here custom methods for repo only
}

public interface IGroupMessagesRepositoryCustom<TEntity>
{
    // add here shared custom methods between repo and service that are not in IBaseRepository
}