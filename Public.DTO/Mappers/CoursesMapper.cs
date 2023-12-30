using AutoMapper;
using DAL.Base;

namespace Public.DTO.Mappers;

public class CoursesMapper : BaseMapper<BLL.DTO.Courses, Public.DTO.v1.CoursesDTO>
{
    public CoursesMapper(IMapper mapper) : base(mapper)
    {
    }
}