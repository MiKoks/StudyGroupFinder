using AutoMapper;
using DAL.Base;

namespace Public.DTO.Mappers;

public class UserCoursesMapper : BaseMapper<BLL.DTO.UserCourses,Public.DTO.v1.UserCoursesDTO>
{
    public UserCoursesMapper(IMapper mapper) : base(mapper)
    {
    }
}