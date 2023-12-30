using AutoMapper;
using DAL.Base;
using DAL.DTO;

namespace BLL.App.Mappers;

public class UserAvailabilitiesMapper : BaseMapper<BLL.DTO.UserAvailabilities, DALUserAvailabilitiesDTO>
{
    public UserAvailabilitiesMapper(IMapper mapper) : base(mapper)
    {
    }
}