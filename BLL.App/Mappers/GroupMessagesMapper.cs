using AutoMapper;
using DAL.Base;
using DAL.DTO;

namespace BLL.App.Mappers;

public class GroupMessagesMapper : BaseMapper<BLL.DTO.GroupMessages, DALGroupMessagesDTO>
{
    public GroupMessagesMapper(IMapper mapper) : base(mapper)
    {
    }
}