using AutoMapper;
using DAL.Base;
using DAL.DTO;

namespace BLL.App.Mappers;

public class StudyGroupsMapper : BaseMapper<BLL.DTO.StudyGroups, DALStudyGroupsDTO>
{
    public StudyGroupsMapper(IMapper mapper) : base(mapper)
    {
    }
}