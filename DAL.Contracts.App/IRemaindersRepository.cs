using DAL.Contracts.Base;
using DAL.DTO;
using Domain.App;

namespace DAL.Contracts.App;

public interface IRemaindersRepository : IBaseRepository<DALRemaindersDTO>, IRemaindersRepositoryCustom<DALRemaindersDTO>
{
    // add here custom methods for repo only
}

public interface IRemaindersRepositoryCustom<TEntity>
{
    // add here shared custom methods between repo and service that are not in IBaseRepository
}