using DAL.Contracts.App;
using DAL.Contracts.Base;

namespace BLL.Contracts.App;

public interface IAppRefreshTokenService : IBaseRepository<BLL.DTO.Identity.AppRefreshToken>,
    IAppRefreshTokenRepositoryCustom<BLL.DTO.Identity.AppRefreshToken>
{
    // add your custom service methods here
    Task<IEnumerable<BLL.DTO.Identity.AppRefreshToken>> GetAllUserRefreshTokens(Guid appUserId);
    Task<IEnumerable<BLL.DTO.Identity.AppRefreshToken>>  GetAppUsersRefreshTokens(Guid appUserId, string logoutRefreshToken);
    Task<IEnumerable<BLL.DTO.Identity.AppRefreshToken>> LoadAndCompareRefreshTokens(Guid appUserId, string refreshToken, DateTime utcNow);
}