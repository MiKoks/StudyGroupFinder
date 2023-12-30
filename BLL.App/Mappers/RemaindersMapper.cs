using AutoMapper;
using DAL.Base;
using DAL.DTO;

namespace BLL.App.Mappers;

public class RemaindersMapper : BaseMapper<BLL.DTO.Remainders, DALRemaindersDTO>
{
    public RemaindersMapper(IMapper mapper) : base(mapper)
    {
    }
}