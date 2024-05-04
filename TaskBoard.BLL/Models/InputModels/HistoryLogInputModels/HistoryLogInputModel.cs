using TaskBoard.BLL.Common.Mapping;
using TaskBoard.DAL.Data.Entities;

namespace TaskBoard.BLL.Models.HistoryLogInputModels;

public class HistoryLogInputModel :  IMapWith<HistoryLog>
{
    public HistoryLogInputModel(Guid cardId, string cardName)
    {
        CardId = cardId;
        CardName = cardName;
    }

    public HistoryLogInputModel() { }

    public Guid? CardId { get; set; }
    public string CardName { get; set; }
    public DateTime ChangeDate { get; private set; } = DateTime.UtcNow;
}