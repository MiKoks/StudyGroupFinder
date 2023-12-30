using AutoMapper;
using DAL.Base;
using DAL.DTO;

namespace DAL.EF.App.Mappers;

public class UserStudyGroupsMapper : BaseMapper<DALUserStudyGroupsDTO, Domain.App.UserStudyGroups>
{
    public UserStudyGroupsMapper(IMapper mapper) : base(mapper)
    {
    }
}