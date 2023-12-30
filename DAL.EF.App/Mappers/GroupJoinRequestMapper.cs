using AutoMapper;
using DAL.Base;

namespace DAL.EF.App.Mappers;

public class GroupJoinRequestMapper : BaseMapper<DAL.DTO.DALGroupJoinRequestsDTO, Domain.App.GroupJoinRequests>
{
    public GroupJoinRequestMapper(IMapper mapper) : base(mapper)
    {
    }
}