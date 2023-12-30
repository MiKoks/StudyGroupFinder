using AutoMapper;
using DAL.Base;

namespace Public.DTO.Mappers;

public class StudyGroupsMapper : BaseMapper<BLL.DTO.StudyGroups,Public.DTO.v1.StudyGroupsDTO>
{
    public StudyGroupsMapper(IMapper mapper) : base(mapper)
    {
    }
}