using DAL.Contracts.App;
using DAL.Contracts.Base;

namespace BLL.Contracts.App;

public interface IRemaindersService : IBaseRepository<BLL.DTO.Remainders>, IRemaindersRepositoryCustom<BLL.DTO.Remainders>
{
    // add your custom service methods here
}