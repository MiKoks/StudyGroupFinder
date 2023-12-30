using AutoMapper;
using DAL.Base;

namespace Public.DTO.Mappers;

public class GroupMessagesMapper : BaseMapper<BLL.DTO.GroupMessages,Public.DTO.v1.GroupMessagesDTO>
{
    public GroupMessagesMapper(IMapper mapper) : base(mapper)
    {
    }
}