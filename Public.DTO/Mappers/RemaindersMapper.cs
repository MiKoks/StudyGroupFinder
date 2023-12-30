using AutoMapper;
using DAL.Base;

namespace Public.DTO.Mappers;

public class RemaindersMapper : BaseMapper<BLL.DTO.Remainders,Public.DTO.v1.RemaindersDTO>
{
    public RemaindersMapper(IMapper mapper) : base(mapper)
    {
    }
}