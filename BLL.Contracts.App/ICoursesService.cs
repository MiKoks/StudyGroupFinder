using DAL.Contracts.Base;
using DAL.Contracts.App;

namespace BLL.Contracts.App;

public interface ICoursesService : IBaseRepository<BLL.DTO.Courses>, ICoursesRepositoryCustom<BLL.DTO.Courses>
{
    // add your custom service methods here
}