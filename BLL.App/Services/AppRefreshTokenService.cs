using BLL.Base;
using BLL.Contracts.App;
using BLL.DTO.Identity;
using Contracts.Base;
using DAL.Contracts.App;

namespace BLL.App.Services;

public class AppRefreshTokenService :
    BaseEntityService<BLL.DTO.Identity.AppRefreshToken, DAL.DTO.Identity.DALAppRefreshTokenDTO, IAppRefreshTokenRepository>,
    IAppRefreshTokenService
{
    protected IAppUOW Uow;

    public AppRefreshTokenService(IAppUOW uow,
        IMapper<BLL.DTO.Identity.AppRefreshToken, DAL.DTO.Identity.DALAppRefreshTokenDTO> mapper)
        : base(uow.AppRefreshTokenRepository, mapper)
    {
        Uow = uow;
    }

    public async Task<IEnumerable<AppRefreshToken>> GetAllUserRefreshTokens(Guid appUserId)
    {
        return (await Repository.GetAllUserRefreshTokens(appUserId)).Select(e => Mapper.Map(e))!;
    }

    public async Task<IEnumerable<AppRefreshToken>> GetAppUsersRefreshTokens(Guid appUserId, string logoutRefreshToken)
    {
        return (await Repository.GetAppUsersRefreshTokens(appUserId, logoutRefreshToken)).Select(e => Mapper.Map(e))!;
    }

    public async Task<IEnumerable<AppRefreshToken>> LoadAndCompareRefreshTokens(Guid appUserId, string refreshToken, DateTime utcNow)
    {
        return (await Repository.LoadAndCompareRefreshTokens(appUserId, refreshToken, utcNow)).Select(e => Mapper.Map(e))!;
    }
}