using AutoMapper;
using DAL.Base;

namespace DAL.EF.App.Mappers;

public class GroupMeetingsMapper : BaseMapper<DAL.DTO.DALGroupMeetingsDTO, Domain.App.GroupMeetings>
{
    public GroupMeetingsMapper(IMapper mapper) : base(mapper)
    {
    }
}