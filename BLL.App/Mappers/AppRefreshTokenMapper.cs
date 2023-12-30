using AutoMapper;
using DAL.Base;
using DAL.DTO.Identity;

namespace BLL.App.Mappers;

public class AppRefreshTokenMapper : BaseMapper<BLL.DTO.Identity.AppRefreshToken, DALAppRefreshTokenDTO>
{
    public AppRefreshTokenMapper(IMapper mapper) : base(mapper)
    {
    }
}