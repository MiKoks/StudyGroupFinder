using AutoMapper;
using DAL.Base;
using DAL.DTO;

namespace DAL.EF.App.Mappers;

public class StudyGroupsMapper : BaseMapper<DALStudyGroupsDTO, Domain.App.StudyGroups>
{
    public StudyGroupsMapper(IMapper mapper) : base(mapper)
    {
    }
}