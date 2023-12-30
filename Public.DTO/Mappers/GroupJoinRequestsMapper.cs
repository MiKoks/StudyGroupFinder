using AutoMapper;
using DAL.Base;

namespace Public.DTO.Mappers;

public class GroupJoinRequestsMapper : BaseMapper<BLL.DTO.GroupJoinRequests, Public.DTO.v1.GroupJoinRequestsDTO>
{
    public GroupJoinRequestsMapper(IMapper mapper) : base(mapper)
    {
    }
}