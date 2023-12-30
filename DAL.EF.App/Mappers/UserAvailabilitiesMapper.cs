using AutoMapper;
using DAL.Base;
using DAL.DTO;

namespace DAL.EF.App.Mappers;

public class UserAvailabilitiesMapper : BaseMapper<DALUserAvailabilitiesDTO, Domain.App.UserAvailabilities>
{
    public UserAvailabilitiesMapper(IMapper mapper) : base(mapper)
    {
    }
}