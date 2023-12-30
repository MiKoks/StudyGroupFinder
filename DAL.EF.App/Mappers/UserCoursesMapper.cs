using AutoMapper;
using DAL.Base;
using DAL.DTO;

namespace DAL.EF.App.Mappers;

public class UserCoursesMapper : BaseMapper<DALUserCoursesDTO, Domain.App.UserCourses>
{
    public UserCoursesMapper(IMapper mapper) : base(mapper)
    {
    }
}