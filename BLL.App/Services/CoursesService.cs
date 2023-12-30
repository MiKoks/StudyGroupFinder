using BLL.Base;
using BLL.Contracts.App;
using BLL.DTO;
using Contracts.Base;
using DAL.Contracts.App;

namespace BLL.App.Services;

public class CoursesService : BaseEntityService<BLL.DTO.Courses, DAL.DTO.DALCoursesDTO, ICoursesRepository>, ICoursesService
{
    protected IAppUOW Uow;

    public CoursesService(IAppUOW uow, IMapper<BLL.DTO.Courses, DAL.DTO.DALCoursesDTO> mapper)
        : base(uow.CoursesRepository, mapper)
    {
        Uow = uow;
    }

    public new async Task<IEnumerable<Courses>> AllAsync()
    {
        return (await Uow.CoursesRepository.AllAsync()).Select(e => Mapper.Map(e))!;
    }

    public new async Task<Courses?> FindAsync(Guid id)
    {
        return Mapper.Map(await Uow.CoursesRepository.FindAsync(id));
    }

}