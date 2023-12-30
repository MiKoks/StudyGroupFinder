using AutoMapper;
using DAL.Base;
using DAL.DTO;

namespace BLL.App.Mappers;

public class GroupMeetingsMapper : BaseMapper<BLL.DTO.GroupMeetings, DALGroupMeetingsDTO>
{
    public GroupMeetingsMapper(IMapper mapper) : base(mapper)
    {
    }
}