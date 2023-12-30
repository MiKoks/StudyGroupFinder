using BLL.Base;
using BLL.Contracts.App;
using BLL.DTO;
using Contracts.Base;
using DAL.Contracts.App;
using DAL.DTO;

namespace BLL.App.Services;

public class UserCoursesService : BaseEntityService<BLL.DTO.UserCourses, DALUserCoursesDTO, IUserCoursesRepository>, IUserCoursesService
{
    protected IAppUOW Uow;

    public UserCoursesService(IAppUOW uow, IMapper<UserCourses, DALUserCoursesDTO> mapper) : base(uow.UserCoursesRepository, mapper)
    {
        Uow = uow;
    }
    
    public new async Task<IEnumerable<UserCourses>> AllAsync()
    {
        return (await Uow.UserCoursesRepository.AllAsync()).Select(e => Mapper.Map(e))!;
    }

    public new async Task<UserCourses?> FindAsync(Guid id)
    {
        return Mapper.Map(await Uow.UserCoursesRepository.FindAsync(id));
    }
}