using DAL.Contracts.App;
using DAL.Contracts.Base;

namespace BLL.Contracts.App;

public interface IUserCoursesService : IBaseRepository<BLL.DTO.UserCourses>, IUserCoursesRepositoryCustom<BLL.DTO.UserCourses>
{
    // add your custom service methods here
}