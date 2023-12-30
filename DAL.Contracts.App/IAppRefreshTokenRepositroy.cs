using DAL.Contracts.Base;
using DAL.DTO.Identity;

namespace DAL.Contracts.App;

public interface IAppRefreshTokenRepository : IBaseRepository<DALAppRefreshTokenDTO>, IAppRefreshTokenRepositoryCustom<DALAppRefreshTokenDTO>
{
    // add here custom methods for repo only
    Task<IEnumerable<DALAppRefreshTokenDTO>> GetAllUserRefreshTokens(Guid appUserId);
    Task<IEnumerable<DALAppRefreshTokenDTO>> GetAppUsersRefreshTokens(Guid appUserId ,string logoutRefreshToken);
    Task<IEnumerable<DALAppRefreshTokenDTO>> LoadAndCompareRefreshTokens(Guid appUserId, string refreshToken, DateTime utcNow);
}

public interface IAppRefreshTokenRepositoryCustom<TEntity>
{
    // add here shared custom methods between repo and service that are not in IBaseRepository
}
