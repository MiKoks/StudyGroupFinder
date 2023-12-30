using AutoMapper;
using DAL.Base;

namespace BLL.App.Mappers;

public class CoursesMapper : BaseMapper<BLL.DTO.Courses, DAL.DTO.DALCoursesDTO>
{
    public CoursesMapper(IMapper mapper) : base(mapper)
    {
    }
}