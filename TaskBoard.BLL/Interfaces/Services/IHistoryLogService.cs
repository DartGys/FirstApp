using TaskBoard.BLL.Models.HistoryLogInputModels;
using TaskBoard.BLL.Models.ViewModels.List;
using TaskBoard.DAL.Data.Entities;

namespace TaskBoard.BLL.Interfaces.Services;

public interface IHistoryLogService
{
    Task<IEnumerable<HistoryLogVm>> GetAllAsync();
    Task<IEnumerable<HistoryLogVm>> GetByCardIdAsync(Guid cardId);
    Task<IEnumerable<HistoryLogVm>> GetTwentyRecord(int lastRecord);
    Task LogAddCardAsync(Guid cardId, string cardName, Guid listId);
    Task LogMoveCardAsync(Guid cardId, string cardName, Guid previousCardList, Guid newCardList);
    Task LogUpdateCardNameAsync(Guid cardId, string cardName, string previousCardName);
    Task LogUpdateCardPriority(Guid cardId, string cardName, Guid previousCardPriorityId, Guid newCardPriorityId);
    Task LogDeleteCard(string cardName, Guid listId);
    Task LogDeleteCardWithList(IEnumerable<string> cardNames, string listName);
    Task CardEqual(Card previousCard, Card newCard);
}