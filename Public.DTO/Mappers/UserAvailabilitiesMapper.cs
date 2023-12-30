using AutoMapper;
using DAL.Base;

namespace Public.DTO.Mappers;

public class UserAvailabilitiesMapper : BaseMapper<BLL.DTO.UserAvailabilities,Public.DTO.v1.UserAvailabilitiesDTO>
{
    public UserAvailabilitiesMapper(IMapper mapper) : base(mapper)
    {
    }
}