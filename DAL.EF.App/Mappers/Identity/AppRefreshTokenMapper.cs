using AutoMapper;
using DAL.Base;

namespace DAL.EF.App.Mappers.Identity;

public class AppRefreshTokenMapper : BaseMapper<DAL.DTO.Identity.DALAppRefreshTokenDTO, Domain.App.Identity.AppRefreshToken>
{
    public AppRefreshTokenMapper(IMapper mapper) : base(mapper)
    {
    }
}