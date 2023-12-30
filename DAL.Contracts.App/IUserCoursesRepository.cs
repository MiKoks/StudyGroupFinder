using DAL.Contracts.Base;
using DAL.DTO;
using Domain.App;

namespace DAL.Contracts.App;

public interface IUserCoursesRepository : IBaseRepository<DALUserCoursesDTO>, IUserCoursesRepositoryCustom<DALUserCoursesDTO>
{
    // add here custom methods for repo only
}

public interface IUserCoursesRepositoryCustom<TEntity>
{
    // add here shared custom methods between repo and service that are not in IBaseRepository
}