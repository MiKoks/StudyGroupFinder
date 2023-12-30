using BLL.Base;
using BLL.Contracts.App;
using BLL.DTO;
using Contracts.Base;
using DAL.Contracts.App;
using DAL.DTO;

namespace BLL.App.Services;

public class StudyGroupsService  : BaseEntityService<BLL.DTO.StudyGroups, DALStudyGroupsDTO, IStudyGroupsRepository>, IStudyGroupsService
{
    protected IAppUOW Uow;

    public StudyGroupsService(IAppUOW uow, IMapper<StudyGroups, DALStudyGroupsDTO> mapper ) : base(uow.StudyGroupsRepository, mapper)
    {
        Uow = uow;
    }
    
    public new async Task<IEnumerable<StudyGroups>> AllAsync()
    {
        return (await Uow.StudyGroupsRepository.AllAsync()).Select(e => Mapper.Map(e))!;
    }

    public new async Task<StudyGroups?> FindAsync(Guid id)
    {
        return Mapper.Map(await Uow.StudyGroupsRepository.FindAsync(id));
    }
    
    
}