using TaskBoard.BLL.Models.ViewModels.List;

namespace TaskBoard.BLL.Interfaces.Services;

public interface IPriorityService
{
    Task<IEnumerable<PriorityVm>> GetAsync();
}