using AutoMapper;
using DAL.Base;

namespace BLL.App.Mappers;

public class AppUserMapper : BaseMapper<BLL.DTO.Identity.AppUser, DAL.DTO.Identity.DALAppUserDTO>
{
    public AppUserMapper(IMapper mapper) : base(mapper)
    {
    }
}