using AutoMapper;
using TaskBoard.BLL.Interfaces.Services;
using TaskBoard.BLL.Models.ViewModels.List;
using TaskBoard.DAL.Interfaces;

namespace TaskBoard.BLL.Services;

public class PriorityService : IPriorityService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PriorityService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<PriorityVm>> GetAsync()
    {
        var entities = await _unitOfWork.Priority.GetAllAsync();

        var priorities = _mapper.Map<IEnumerable<PriorityVm>>(entities);

        return priorities;
    }

    public async Task<PriorityVm> GetById(Guid id)
    {
        var entity = await _unitOfWork.Priority.GetById(id);

        var priority = _mapper.Map<PriorityVm>(entity);

        return priority;
    }
}