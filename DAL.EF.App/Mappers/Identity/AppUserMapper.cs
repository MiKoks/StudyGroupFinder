using AutoMapper;
using DAL.Base;

namespace DAL.EF.App.Mappers.Identity;

public class AppUserMapper : BaseMapper<DAL.DTO.Identity.DALAppUserDTO, Domain.App.Identity.AppUser>
{
    public AppUserMapper(IMapper mapper) : base(mapper)
    {
    }
}