using TaskBoard.BLL.Models.HistoryLogInputModels;
using TaskBoard.BLL.Models.ViewModels.List;

namespace TaskBoard.BLL.Interfaces.Services;

public interface IHistoryLogService
{
    Task<IEnumerable<HistoryLogVm>> GetAllAsync();
    Task<IEnumerable<HistoryLogVm>> GetByCardIdAsync(Guid cardId);
    Task LogAddCardAsync(HistoryLogAddCard input);
    Task LogMoveCardASync(HistoryLogUpdateCardList input);
    Task LogUpdateCardNameAsync(HistoryLogUpdateCardName input);
    Task LogUpdateCardPriority(HistoryLogUpdateCardPriority input);
    Task LogDeleteCard(HistoryLogDeleteCard input);
}