using AutoMapper;
using DAL.Base;

namespace Public.DTO.Mappers;

public class UserStudyGroupsMapper : BaseMapper<BLL.DTO.UserStudyGroups, Public.DTO.v1.UserStudyGroupsDTO>
{
    public UserStudyGroupsMapper(IMapper mapper) : base(mapper)
    {
    }
}