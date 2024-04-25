using AutoMapper;
using TaskBoard.BLL.Interfaces.Services;
using TaskBoard.BLL.Models.HistoryLogInputModels;
using TaskBoard.BLL.Models.ViewModels.List;
using TaskBoard.DAL.Data.Entities;
using TaskBoard.DAL.Interfaces;

namespace TaskBoard.BLL.Services;

public class HistoryLogService : IHistoryLogService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public HistoryLogService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<HistoryLogVm>> GetAllAsync()
    {
        var entities = await _unitOfWork.HistoryLog.GetAllAsync();

        var historyLogs = _mapper.Map<IEnumerable<HistoryLogVm>>(entities);

        return historyLogs;
    }

    public async Task<IEnumerable<HistoryLogVm>> GetByCardIdAsync(Guid cardId)
    {
        var entities = await _unitOfWork.HistoryLog.FindAsyncNoTracking(x => x.CardId == cardId);

        var historyLog = _mapper.Map<IEnumerable<HistoryLogVm>>(entities);

        return historyLog;
    }

    public async Task LogAddCardAsync(HistoryLogInputModel input)
    {
        var model = (HistoryLogAddCard)input;
        var entity = _mapper.Map<HistoryLog>(model);

        await _unitOfWork.HistoryLog.AddAsync(entity);
        await _unitOfWork.SaveChangeAsync();
    }

    public async Task LogMoveCardAsync(HistoryLogInputModel input)
    {
        var model = (HistoryLogUpdateCardList)input;
        var entity = _mapper.Map<HistoryLog>(model);

        await _unitOfWork.HistoryLog.AddAsync(entity);
        await _unitOfWork.SaveChangeAsync();
    }

    public async Task LogUpdateCardNameAsync(HistoryLogInputModel input)
    {
        var model = (HistoryLogUpdateCardName)input;
        var entity = _mapper.Map<HistoryLog>(model);

        await _unitOfWork.HistoryLog.AddAsync(entity);
        await _unitOfWork.SaveChangeAsync();
    }

    public async Task LogUpdateCardPriority(HistoryLogInputModel input)
    {
        var model = (HistoryLogUpdateCardPriority)input;
        var entity = _mapper.Map<HistoryLog>(model);

        await _unitOfWork.HistoryLog.AddAsync(entity);
        await _unitOfWork.SaveChangeAsync();
    }

    public async Task LogDeleteCard(HistoryLogInputModel input)
    {
        var model = (HistoryLogDeleteCard)input;
        var entity = _mapper.Map<HistoryLog>(model);

        await _unitOfWork.HistoryLog.AddAsync(entity);
        await _unitOfWork.SaveChangeAsync();
    }
}