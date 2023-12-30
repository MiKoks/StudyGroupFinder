using AutoMapper;
using DAL.Base;

namespace Public.DTO.Mappers;

public class GroupMeetingsMapper : BaseMapper<BLL.DTO.GroupMeetings,Public.DTO.v1.GroupMeetingsDTO>
{
    public GroupMeetingsMapper(IMapper mapper) : base(mapper)
    {
    }
}