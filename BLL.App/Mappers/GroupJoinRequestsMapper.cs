using AutoMapper;
using DAL.Base;

namespace BLL.App.Mappers;

public class GroupJoinRequestsMapper : BaseMapper<BLL.DTO.GroupJoinRequests, DAL.DTO.DALGroupJoinRequestsDTO>
{
    public GroupJoinRequestsMapper(IMapper mapper) : base(mapper)
    {
    }
}