using AutoMapper;
using DAL.Base;

namespace DAL.EF.App.Mappers;

public class CoursesMapper : BaseMapper<DAL.DTO.DALCoursesDTO, Domain.App.Courses>
{
    public CoursesMapper(IMapper mapper) : base(mapper)
    {
    }
}