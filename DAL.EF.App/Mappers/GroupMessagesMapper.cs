using AutoMapper;
using DAL.Base;

namespace DAL.EF.App.Mappers;

public class GroupMessagesMapper : BaseMapper<DAL.DTO.DALGroupMessagesDTO, Domain.App.GroupMessages>
{
    public GroupMessagesMapper(IMapper mapper) : base(mapper)
    {
    }
}