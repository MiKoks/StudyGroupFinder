using DAL.Contracts.App;
using DAL.Contracts.Base;
using DAL.DTO;

namespace BLL.Contracts.App;

public interface IGroupMessagesService : IBaseRepository<BLL.DTO.GroupMessages>, IGroupMessagesRepositoryCustom<BLL.DTO.GroupMessages>
{
    public async Task SaveChatMessageAsync(DALGroupMessagesDTO message)
    {
        /*Uow.GroupMessagesRepository.Add(message);
        await Uow.SaveChangesAsync();*/
    }
    // add your custom service methods here
}