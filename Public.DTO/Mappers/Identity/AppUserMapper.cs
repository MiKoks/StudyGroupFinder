using AutoMapper;
using DAL.Base;

namespace Public.DTO.Mappers.Identity;

public class AppUserMapper : BaseMapper<BLL.DTO.Identity.AppUser, Public.DTO.v1.AppUser>
{
    public AppUserMapper(IMapper mapper) : base(mapper)
    {
    }
}