using AutoMapper;
using DAL.Base;
using DAL.DTO;

namespace BLL.App.Mappers;

public class UserCoursesMapper : BaseMapper<BLL.DTO.UserCourses, DALUserCoursesDTO>
{
    public UserCoursesMapper(IMapper mapper) : base(mapper)
    {
    }
}