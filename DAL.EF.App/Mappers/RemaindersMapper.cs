using AutoMapper;
using DAL.Base;

namespace DAL.EF.App.Mappers;

public class RemaindersMapper : BaseMapper<DAL.DTO.DALRemaindersDTO, Domain.App.Remainders>
{
    public RemaindersMapper(IMapper mapper) : base(mapper)
    {
    }
}