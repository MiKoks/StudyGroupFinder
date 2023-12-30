using AutoMapper;
using DAL.Base;
using DAL.DTO;

namespace BLL.App.Mappers;

public class UserStudyGroupsMapper : BaseMapper<BLL.DTO.UserStudyGroups, DALUserStudyGroupsDTO>
{
    public UserStudyGroupsMapper(IMapper mapper) : base(mapper)
    {
    }
}