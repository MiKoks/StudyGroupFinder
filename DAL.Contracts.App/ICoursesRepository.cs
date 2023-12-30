using DAL.Contracts.Base;
using Domain.App;

namespace DAL.Contracts.App;

public interface ICoursesRepository : IBaseRepository<DAL.DTO.DALCoursesDTO>, ICoursesRepositoryCustom<DAL.DTO.DALCoursesDTO>
{
    // add here custom methods for repo only
}

public interface ICoursesRepositoryCustom<TEntity>
{
    // add here shared custom methods between repo and service that are not in IBaseRepository
}