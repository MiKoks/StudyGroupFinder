using AutoMapper;
using Contracts.Base;
using DAL.Contracts.App;
using DAL.DTO.Identity;
using DAL.EF.Base;
using Domain.App.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.App.Repositories;

public class AppRefreshTokenRepository :
    EFBaseRepository<DAL.DTO.Identity.DALAppRefreshTokenDTO, Domain.App.Identity.AppRefreshToken, ApplicationDbContext>,
    IAppRefreshTokenRepository
{
    public AppRefreshTokenRepository(ApplicationDbContext dataContext,
        IMapper<DAL.DTO.Identity.DALAppRefreshTokenDTO, Domain.App.Identity.AppRefreshToken> mapper) : base(dataContext,
        mapper)
    {
    }

    public async Task<IEnumerable<DALAppRefreshTokenDTO>> GetAllUserRefreshTokens(Guid appUserId)
    {
        var res = (await RepositoryDbSet
            .Where(t => t.AppUserId == appUserId)
            .ToListAsync());

        return res.Select(x => Mapper.Map(x)!);
    }

    public async Task<IEnumerable<DALAppRefreshTokenDTO>> LoadAndCompareRefreshTokens(Guid appUserId, string refreshToken,
        DateTime utcNow)
    {

        var res = (await RepositoryDbSet
            .Where(t => t.AppUserId == appUserId && (
                (t.RefreshToken == refreshToken && t.ExpirationDT > utcNow) ||
                (t.PreviousRefreshToken == refreshToken &&
                 t.PreviousExpirationDT > utcNow)
            ))
            .ToListAsync());

        return res.Select(x => Mapper.Map(x)!);
    }

    public async Task<IEnumerable<DALAppRefreshTokenDTO>> GetAppUsersRefreshTokens(Guid appUserId, string logoutRefreshToken)
    {
        var res = (await RepositoryDbSet
            .Where(t => t.AppUserId == appUserId && (
                (t.RefreshToken == logoutRefreshToken) ||
                (t.PreviousRefreshToken == logoutRefreshToken)
            ))
            .ToListAsync());

        return res.Select(x => Mapper.Map(x)!);
    }
}