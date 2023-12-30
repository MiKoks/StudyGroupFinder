using DAL.Contracts.Base;
using DAL.DTO;
using Domain.App;

namespace DAL.Contracts.App;

public interface IUserAvailabilitiesRepository  : IBaseRepository<DALUserAvailabilitiesDTO>, IUserAvailabilitiesRepositoryCustom<DALUserAvailabilitiesDTO>
{
    // add here custom methods for repo only
}

public interface IUserAvailabilitiesRepositoryCustom<TEntity>
{
    // add here shared custom methods between repo and service that are not in IBaseRepository
}